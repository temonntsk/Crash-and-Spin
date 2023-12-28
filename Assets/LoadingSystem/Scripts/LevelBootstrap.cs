using UnityEngine;

public class LevelBootstrap : MonoBehaviour
{
    [SerializeField] private MoneyDisplay _moneyDisplay;
    //[SerializeField] private SoundSetting _soundSetting;

    private Money _money;

    private void Awake()
    {
        SaveSystem.Load(OnLoadData);
    }

    private void OnLoadData(Data data)
    {
        _money = new Money(data.Money);
       //_soundSetting.Mute(data.IsMute);
        _moneyDisplay.Initialize(_money);
    }
}