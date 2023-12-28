using System;
using System.Collections;
using Agava.WebUtility;
using Agava.YandexGames;
using UnityEngine;

public class YandexSDK : MonoBehaviour
{
    public static YandexSDK Instance = null;

    private bool _isAdRunning;
    private bool _isRewarded;
    private bool _isMute;

    public bool IsInitialize { get; private set; }

    public event Action Initialized;
    public event Action ShowedInterstitianal;
    public event Action ShowedRewarded;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    public void StartInitialize()
    {
        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
#if UNITY_EDITOR
        Initialized?.Invoke();
        IsInitialize = true;
        Debug.Log("SDK Initialized");
        yield break;
#endif
        yield return YandexGamesSdk.Initialize(OnInitialize);
    }

    private void OnInitialize()
    {
        IsInitialize = true;
        Initialized?.Invoke();
        ShowInterstitial();
        Debug.Log("SDK Initialized");
    }

    public void ShowInterstitial(Action onOpenCallback = null, Action onCloseCallback = null)
    {
        void onOpenAction()
        {
            onOpenCallback?.Invoke();
            MuteAudio(true);
            ShowedInterstitianal?.Invoke();
        }

        void onCloseAction(bool wasShown)
        {
            onCloseCallback?.Invoke();
            MuteAudio(_isMute);
        }

#if UNITY_EDITOR
        onOpenAction();
        onCloseAction(true);
        return;
#endif
        InterstitialAd.Show(onOpenAction, onCloseAction);
    }

    public void ShowVideoAd(Action onRewardedCallback = null, Action onOpenCallback = null, Action onCloseCallback = null)
    {
        void onOpenAction()
        {
            StartCoroutine(CheckRewarded());

            onOpenCallback?.Invoke();
            MuteAudio(true);

            _isAdRunning = true;
        }

        void onCloseAction()
        {
            onCloseCallback?.Invoke();
            MuteAudio(_isMute);

            _isAdRunning = false;
        }

        void onRewardedAction()
        {
            onRewardedCallback?.Invoke();

            _isRewarded = true;
        }

#if UNITY_EDITOR
        onOpenAction();
        onRewardedAction();
        onCloseAction();
        return;
#endif
        VideoAd.Show(onOpenAction, onRewardedAction, onCloseAction);
    }

    public void ChangeStateAudioMute(bool state)
    {
        _isMute = state;
    }

    private IEnumerator CheckRewarded()
    {
        while (_isRewarded == false)
            yield return null;

        ShowedRewarded?.Invoke();
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        if (!_isAdRunning)
            MuteAudio(inBackground);
    }

    public void MuteAudio(bool value)
    {
        AudioListener.pause = value;
        AudioListener.volume = value ? 0f : 1f;
    }
}