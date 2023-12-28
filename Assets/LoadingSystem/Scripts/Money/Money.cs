using System;
using UnityEngine;

[Serializable]
public class Money
{
    private readonly int _minValue = 0; 

    public int Value { get; private set; }

    public event Action<int> MoneyChanged;

    public Money(int value) => Value = value;

    public void AddMoney(int value)
    {
        Value += value;
        MoneyChanged?.Invoke(Value);

        SaveSystem.CurrentData.Money = Value;
        SaveSystem.Save();
    }

    public void TakeMoney(int value)
    {
        Value = Mathf.Max(Value - value, _minValue);
        MoneyChanged?.Invoke(Value);

        SaveSystem.CurrentData.Money = Value;
        SaveSystem.Save();
    }
}