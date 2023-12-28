using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;

[RequireComponent(typeof(CanvasGroup))]
public class ADTimer : MonoBehaviour
{
    [LabelText("Тип таймера")][EnumPaging]
    [SerializeField] private TypeAdTimer _typeAdTimer;

    [LabelText("Общее время")]
    [SuffixLabel("c", Overlay = true)][MinValue(0)]
    [SerializeField] private float _totalSecondToShowAd = 60;
    
    [LabelText("Время до появления дисплея")]
    [SuffixLabel("c", Overlay = true)][MinValue(0)]
    [SerializeField] private float _timeToShowDisplay = 5f;
    
    [LabelText("Текст минут/секунд")]
    [SerializeField] private TMP_Text _timerText;
    
    [LabelText("Текст таймера (сверху)")]
    [ShowIf("_typeAdTimer", TypeAdTimer.TextTimer)]
    [SerializeField] private TMP_Text _label;
    
    [LabelText("Бар")][ShowIf("_typeAdTimer", TypeAdTimer.BarTimer)]
    [SerializeField] private Image _bar;

    [LabelText("Иконка рекламы")]
    [ShowIf("_typeAdTimer", TypeAdTimer.BarTimer)]
    [SerializeField] private Image _icon;

    private float _currentTime;
    private YandexSDK _yandexSDK;
    private CanvasGroup _canvasGroup;
    private bool _isActiveBar;

    private void OnValidate()
    {
        if (_typeAdTimer == TypeAdTimer.TextTimer)
        {
            _label.gameObject.SetActive(true);
            _bar.gameObject.SetActive(false);
            _icon.gameObject.SetActive(false);
        }

        if (_typeAdTimer == TypeAdTimer.BarTimer)
        {
            _label.gameObject.SetActive(false);
            _bar.gameObject.SetActive(true);
            _icon.gameObject.SetActive(true);
        }
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _yandexSDK = YandexSDK.Instance;
    }

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        if (_currentTime > 0f)
        {
            _currentTime -= Time.deltaTime;

            UpdateTimerText();

            if(_currentTime <= _timeToShowDisplay && _canvasGroup.alpha == 0)
            {
                _canvasGroup.alpha = 1f;
                _isActiveBar = true;
            }

            if (_currentTime <= 0f)
            {
                TimerExpired();
                StartTimer();
            }

            if(_isActiveBar && _typeAdTimer == TypeAdTimer.BarTimer)
            {
                _bar.fillAmount = (_currentTime / _timeToShowDisplay);
            }
        }
    }

    private void StartTimer()
    {
        _canvasGroup.alpha = 0f;
        _isActiveBar = false;
        _currentTime = _totalSecondToShowAd;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        if (_timerText != null)
        {
            int minutes = Mathf.FloorToInt(_currentTime / 60f);
            int seconds = Mathf.FloorToInt(_currentTime % 60f);

            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void TimerExpired()
    {
        Debug.Log("Показываем рекламу");

#if UNITY_WEBGL && !UNITY_EDITOR
        _yandexSDK.ShowInterstitial(OnOpenCallnack, OnCloseCallback);  
#endif
    }

    private void OnOpenCallnack()
    {
        Time.timeScale = 0;
    }

    private void OnCloseCallback()
    {
        Time.timeScale = 1;
    }
}

public enum TypeAdTimer
{
    BarTimer, TextTimer
}