using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerParameter
{
    private const float MultiplierUpgradeParameters = 1.2f;

    private string _firstlevel = "1Level";//сделать сцен лоудер там будет конфиг 

    private float _maxHealth;
    private float _weaponForce;
    private float _movementSpeed;
    private float _rotationSpeed;

    private Dictionary<Parameter, float> _valueParametersPairs;
    private Dictionary<Parameter, string> _nameParametersPairs;

    public PlayerParameter()
    {
        if (SceneManager.GetActiveScene().name == _firstlevel)
        {
            FillDefaultValues();
        }
        else
        {
            ApplySafeParameter();
        }
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

        _valueParametersPairs = new Dictionary<Parameter, float>()
        {
            {Parameter.MaxHealth, _maxHealth},
            {Parameter.WeaponForce, _weaponForce},
            {Parameter.MovementSpeed, _movementSpeed},
            {Parameter.RotationSpeed, _rotationSpeed}
        };

        _nameParametersPairs = new Dictionary<Parameter, string>()
        {
            {Parameter.MaxHealth, "MaxHealth"},
            {Parameter.WeaponForce, "WeaponForce"},
            {Parameter.MovementSpeed, "MovementSpeed"},
            {Parameter.RotationSpeed, "RotationSpeed"}
        };

        foreach (var value in _valueParametersPairs)
        {
            SafeParameter(value.Key, value.Value);
        }
    }

    public void UpgradeParameters(Parameter parameter)
    {
        if (_valueParametersPairs.ContainsKey(parameter))
        {
            _valueParametersPairs[parameter] *= MultiplierUpgradeParameters;

            SafeParameter(parameter, _valueParametersPairs[parameter]);
        }
    }

    private void SafeParameter(Parameter parameter, float valueParameter)
    {
        if (_nameParametersPairs.ContainsKey(parameter))
        {
            PlayerPrefs.SetFloat(_nameParametersPairs[parameter], valueParameter);
        }
    }

    private void ApplySafeParameter()
    {
        foreach (var name in _nameParametersPairs)
        {
            if (_valueParametersPairs.ContainsKey(name.Key))
            {
                _valueParametersPairs[name.Key] = PlayerPrefs.GetFloat(_nameParametersPairs[name.Key]);
            }
        }
    }
}