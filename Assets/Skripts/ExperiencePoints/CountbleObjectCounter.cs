using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountbleObjectCounter : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private PlayerLevelUp _playerLevelUp;

    private ÑalculatorExperiencePoint _ñalculator;

    private Collider[] _overLappedColliders = new Collider[50];
    private List<ICountble> _countbleObjects = new List<ICountble>();

    private int _countObjectInLevel;
    private int _countObjectCounted;

    private void OnEnable()
    {
        foreach (var countbleObject in _countbleObjects)
        {
            countbleObject.ObjectCounted += OnObjectCounted;
        }
    }

    private void OnDisable()
    {
        foreach (var countbleObject in _countbleObjects)
        {
            countbleObject.ObjectCounted -= OnObjectCounted;
        }
    }

    private void Awake()
    {
        Search();
        _ñalculator = new ÑalculatorExperiencePoint();
    }

    private void OnObjectCounted()
    {
        _countObjectCounted++;

        Quantify();
    }

    private void Search()
    {
        Vector3 center = transform.position;

        Physics.OverlapSphereNonAlloc(center, _radius, _overLappedColliders, _layerMask);

        foreach (var collider in _overLappedColliders)
        {
            if (collider == null)
            {
                continue;
            }

            if (collider.TryGetComponent(out ICountble countbleObject))
            {
                _countObjectInLevel++;

                _countbleObjects.Add(countbleObject);
            }
        }
    }

    private void Quantify()
    {
        if (_countObjectInLevel == _countObjectCounted)
        {
            _playerLevelUp.TakePoints(_ñalculator.CalculateExperiencePoint(Time.time));
        }
    }
}
