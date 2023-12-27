using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ExclamationMarkEnemy : MonoBehaviour
{
    [SerializeField] private Camera _Camera;

    private Coroutine _changeExclamationMark;
    private Image _image;

    private float _focusDelay;
    private float _minFillAmount;
    private float _maxFillAmount;
    private float _fillSpeed;
    private float _increase;
    private float _decrease;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 0f;
        _minFillAmount = 0f;
        _maxFillAmount = 1f;
        _increase = 1f;
        _decrease = -1f;
    }

    private void FixedUpdate()
    {
        transform.LookAt(_Camera.transform);
    }

    public void Initialization(float focusDelay)
    {
        _focusDelay = focusDelay;
        _fillSpeed = Mathf.Abs(_maxFillAmount - _minFillAmount) / _focusDelay;
    }

    public void ToFill()
    {
        StopCoroutineChangeVolume();
        _changeExclamationMark = StartCoroutine(ChangeFill(_increase));
    }

    public void ToEmpty()
    {
        StopCoroutineChangeVolume();
        _changeExclamationMark = StartCoroutine(ChangeFill(_decrease));
    }

    private IEnumerator ChangeFill(float target)
    {
        float time = 0;

        while (time < _focusDelay)
        {
            _image.fillAmount += target * (_fillSpeed * Time.deltaTime);
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