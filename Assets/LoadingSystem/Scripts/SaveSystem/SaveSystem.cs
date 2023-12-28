using Agava.YandexGames;
using UnityEngine;
using System;

public static class SaveSystem
{
    private const string KEY_DATA = "KEY_DATA";

    public static Data CurrentData { get; private set; } = new Data();

    public static void Save()
    {
        string key = JsonUtility.ToJson(CurrentData);
        UnityEngine.PlayerPrefs.SetString(KEY_DATA, key);

#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerAccount.SetCloudSaveData(key);
#endif
    }

    public static void Load(Action<Data> onLoadComplete)
    {
        string key = UnityEngine.PlayerPrefs.GetString(KEY_DATA);

#if UNITY_EDITOR
        LoadLocalData(key);
        onLoadComplete?.Invoke(CurrentData);
#else
        PlayerAccount.GetCloudSaveData(
            (cloudData) =>
            {
                LoadCloudData(cloudData);
                onLoadComplete?.Invoke(CurrentData);
            },
            (localData) =>
            {
                LoadLocalData(localData);
                onLoadComplete?.Invoke(CurrentData);
            }
        );
#endif
    }

    private static void LoadCloudData(string key) => DecryptKey(key);

    private static void LoadLocalData(string key) => DecryptKey(key);

    private static void DecryptKey(string key)
    {
        Data data = JsonUtility.FromJson<Data>(key);

        if (data != null)
            CurrentData = data;
    }
}