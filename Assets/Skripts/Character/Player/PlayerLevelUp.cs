using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUp : MonoBehaviour
{
    private const float MultiplierUpgradePrice = 1.3f;

    [SerializeField] private float _upgradePrice;
    [SerializeField] private Button _upgradeMaxHealth;
    [SerializeField] private Button _upgradeWeaponForce;
    [SerializeField] private Button _upgradeMovementSpeed;
    [SerializeField] private Button _upgradeRotationSpeed;


    private �alculatorExperiencePoint _�alculator;
    private PlayerParameter _stats;
    private int _experiencePoint;
    private Dictionary<Button, Parameter> _buttonParametersPairs;


    private void Awake()
    {
        _�alculator = new �alculatorExperiencePoint();
        _stats = new PlayerParameter();

        _buttonParametersPairs = new Dictionary<Button, Parameter>()
        {
            {_upgradeMaxHealth,Parameter.MaxHealth },
            {_upgradeWeaponForce,Parameter.WeaponForce},
            {_upgradeMovementSpeed,Parameter.MovementSpeed},
            {_upgradeRotationSpeed,Parameter.RotationSpeed}
        };
    }

    private void OnEnable()
    {
        _�alculator.ExperiencePointsCalculated += OnExperiencePointsCalculated;
        _upgradeMaxHealth.onClick.AddListener(OnButtonClickMaxHealth);
        _upgradeWeaponForce.onClick.AddListener(OnButtonClickWeaponForce);
        _upgradeMovementSpeed.onClick.AddListener(OnButtonClickMovementSpeed);
        _upgradeRotationSpeed.onClick.AddListener(OnButtonClickRotationSpeed);
    }

    private void OnDisable()
    {
        _�alculator.ExperiencePointsCalculated -= OnExperiencePointsCalculated;
        _upgradeMaxHealth.onClick.RemoveListener(OnButtonClickMaxHealth);
        _upgradeWeaponForce.onClick.RemoveListener(OnButtonClickWeaponForce);
        _upgradeMovementSpeed.onClick.RemoveListener(OnButtonClickMovementSpeed);
        _upgradeRotationSpeed.onClick.RemoveListener(OnButtonClickRotationSpeed);
    }

    private void OnExperiencePointsCalculated(int experiencePoint)
    {
        _experiencePoint = experiencePoint;
        //��� ���������� ������ � ����� �������� � �������� 
    }
    private bool TrySpendPoints()
    {
        if (_experiencePoint >= _upgradePrice)
        {
            _experiencePoint -= Convert.ToInt32(_upgradePrice);
            return true;
        }

        return false;
    }

    private void OnButtonClickMaxHealth()
    {
        if (TrySpendPoints())
        {
            _upgradePrice *= MultiplierUpgradePrice;
            _stats.UpgradeParameters(_buttonParametersPairs[_upgradeMaxHealth]);
        }
        else
        {
            print("����� �� �������");
            //����� �������� ������
        }
    }

    private void OnButtonClickRotationSpeed()
    {
        if (TrySpendPoints())
        {
            _upgradePrice *= MultiplierUpgradePrice;
            _stats.UpgradeParameters(_buttonParametersPairs[_upgradeRotationSpeed]);
        }
        else
        {
            print("����� �� �������");
            //����� �������� ������
        }
    }

    private void OnButtonClickMovementSpeed()
    {
        if (TrySpendPoints())
        {
            _upgradePrice *= MultiplierUpgradePrice;
            _stats.UpgradeParameters(_buttonParametersPairs[_upgradeMovementSpeed]);
        }
        else
        {
            print("����� �� �������");
            //����� �������� ������
        }
    }

    private void OnButtonClickWeaponForce()
    {
        if (TrySpendPoints())
        {
            _upgradePrice *= MultiplierUpgradePrice;
            _stats.UpgradeParameters(_buttonParametersPairs[_upgradeWeaponForce]);
        }
        else
        {
            print("����� �� �������");
            //����� �������� ������
        }
    }
}
