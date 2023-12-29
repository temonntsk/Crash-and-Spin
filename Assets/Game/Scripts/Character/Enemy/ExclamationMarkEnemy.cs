using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ExclamationMarkEnemy : MonoBehaviour
{
    private const float MinFillAmount = 0f;
    private const float MaxFillAmount = 1f;
    private const float Increase = 1f;
    private const float Decrease = -1f;

    [SerializeField] private Camera _Camera;

    private Coroutine _changeExclamationMark;
    private Image _image;

    private float _focusDelay;
    private float _fillSpeed;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 0f;
    }

    private void FixedUpdate()
    {
        transform.LookAt(_Camera.transform);
    }

    public void Initialization(float focusDelay)
    {
        _focusDelay = focusDelay;
        _fillSpeed = Mathf.Abs(MaxFillAmount - MinFillAmount) / _focusDelay;
    }

    public void ToFill()
    {
        StopCoroutineChangeVolume();
        _changeExclamationMark = StartCoroutine(ChangeFill(Increase));
    }

    public void ToEmpty()
    {
        StopCoroutineChangeVolume();
        _changeExclamationMark = StartCoroutine(ChangeFill(Decrease));
    }

    private IEnumerator ChangeFill(float target)
    {
        float time = 0;

        while (time < _focusDelay)
        {
            _image.fillAmount += target * (_fillSpeed * Time.deltaTime);
            Debug.Log(_image.fillAmount);
            time += Time.deltaTime;
            yield return null;
        }
    }

    private void StopCoroutineChangeVolume()
    {
        if (_changeExclamationMark != null)
            StopCoroutine(_changeExclamationMark);
    }
}