using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ExclamationMarkEnemy : MonoBehaviour
{
    //[SerializeField] private float _lerpDuration;

    //private Image _image;
    //private float _startAmount;
    //private float _endAmount;

    //private void Awake()
    //{
    //    _image = GetComponent<Image>();
    //    _image.fillAmount = 1f;
    //    _startAmount = 0;
    //    _endAmount = 1;
    //}

    //public void ToFill()
    //{
    //    StartCoroutine(Filling(_startAmount, _endAmount, _lerpDuration, Fill));
    //}

    //public void ToEmpty()
    //{
    //    StartCoroutine(Filling(_endAmount, _startAmount, _lerpDuration, Destroy));
    //}

    //private void Destroy(float value)
    //{
    //    _image.fillAmount = value;
    //    Destroy(gameObject);
    //}

    //private void Fill(float value)
    //{
    //    _image.fillAmount = value;
    //}

    //private IEnumerator Filling(float startValue, float endValue, float duration, Action<float> lerpigEnd)
    //{
    //    float elapsed = 0;
    //    float nextValue;

    //    while (elapsed < duration)
    //    {
    //        nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
    //        _image.fillAmount = nextValue;
    //        elapsed += Time.deltaTime;
    //        yield return null;
    //    }

    //    lerpigEnd?.Invoke(endValue);
    //}

    public Image image;
    public float animationTime = 5f;
    public float targetFillAmount = 1f;

    private void Start()
    {
        StartCoroutine(AnimateImageFill());
    }

    private IEnumerator AnimateImageFill()
    {
        float startFillAmount = image.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < animationTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / animationTime);

            image.fillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, t);

            yield return null;
        }
    }
}
