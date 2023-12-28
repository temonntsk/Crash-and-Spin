using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private Button _on;
    [SerializeField] private Button _off;

    public void Mute(bool state)
    {
        _on.gameObject.SetActive(!state);
        _off.gameObject.SetActive(state);

        AudioListener.pause = state;
        AudioListener.volume = state ? 0f : 1f;

        SaveSystem.CurrentData.IsMute = state;
        SaveSystem.Save();
    }
}