using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private Transform _particleFolder;
    [SerializeField] private TMP_Text _percent;
    [SerializeField] private float _speedAnimationLoad;

    private AsyncOperation _asyncOperation;
    private float _progress;
    private float _currentProgress;
    private bool _isLoad;
    private YandexSDK _yandexSDK;
    private bool _isSdkInitialized;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
        _yandexSDK = YandexSDK.Instance;
        _yandexSDK.Initialized += OnInitialized;
    }

    private void OnDisable()
    {
        _yandexSDK.Initialized -= OnInitialized;
    }

    private void Update()
    {
        if (_currentProgress != _progress)
        {
            _isLoad = false;
            _currentProgress = Mathf.MoveTowards(_currentProgress, _progress, _speedAnimationLoad * Time.deltaTime);
            _bar.fillAmount = _currentProgress;
            _particleFolder.rotation = Quaternion.Euler(new Vector3(0, 0, -_currentProgress * 360));
            _percent.text = Mathf.Round(_currentProgress * 100f) + "%";
        }

        if (_currentProgress == 1f)
        {
            _isLoad = true;
            _yandexSDK.StartInitialize();
        }
    }

    private void OnInitialized()
    {
        _isSdkInitialized = true;
    }

    private IEnumerator LoadSceneAsync()
    {
        Debug.Log("Loading game scene");
        _asyncOperation = SceneManager.LoadSceneAsync(1);
        _asyncOperation.allowSceneActivation = false;

        while (!_asyncOperation.isDone)
        {
            _progress = Mathf.Clamp01(_asyncOperation.progress / 0.9f);

            if (_asyncOperation.progress >= 0.9f && _isLoad && _isSdkInitialized)
            {
                _progress = 1;
                _asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
