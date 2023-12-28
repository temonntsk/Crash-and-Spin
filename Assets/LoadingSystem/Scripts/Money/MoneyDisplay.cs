using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    private const string CHANGE_MONEY = "ChangeMoney";

    [SerializeField] private TMP_Text _label;
    [SerializeField] private Animator _animator;

    private Money _money;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _money.AddMoney(100);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _money.TakeMoney(100);
        }
    }

    public void Initialize(Money money)
    {
        _money = money;
        _money.MoneyChanged += OnMoneyChanged;
        _label.text = _money.Value.ToString();
    }

    private void OnDisable()
    {
        _money.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int value)
    {
        _label.text = value.ToString();
        _animator.Play(CHANGE_MONEY);
    }
}