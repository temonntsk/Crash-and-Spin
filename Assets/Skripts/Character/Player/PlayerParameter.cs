using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerParameter
{
    private const float MultiplierUpgradeParameters = 1.2f;

    private string _firstLevle = "SampleScene";

    private float _maxHealth;
    private float _weaponForce;
    private float _movementSpeed;
    private float _rotationSpeed;

    private Dictionary<Parameter, float> _valueParametersPairs;
    //сохранять в префсы (юнити инструент)
    //деламем на тойже игровой сцене  прокачку (канвас окно) 


    public PlayerParameter()
    {
        if (SceneManager.GetActiveScene().name == _firstLevle)
            FillDefaultValues();

        _valueParametersPairs = new Dictionary<Parameter, float>()
        {
            {Parameter.MaxHealth, _maxHealth},
            {Parameter.WeaponForce, _weaponForce},
            {Parameter.MovementSpeed, _movementSpeed},
            {Parameter.RotationSpeed, _rotationSpeed}
        };
    }

    public float MaxHealth => _maxHealth;
    public float WeaponForce => _weaponForce;
    public float MovementSpeed => _movementSpeed;
    public float RotationSpeed => _rotationSpeed;

    private void FillDefaultValues()
    {
        _maxHealth = 3;
        _weaponForce = 15;
        _movementSpeed = 5;
        _rotationSpeed = 200;
    }

    public void UpgradeParameters(Parameter parameter)
    {
        if (_valueParametersPairs.ContainsKey(parameter))
        {
            _valueParametersPairs[parameter] *= MultiplierUpgradeParameters;
        }
    }
}