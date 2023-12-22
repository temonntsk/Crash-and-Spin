using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountbleObjectCounter : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    private —alculatorExperiencePoint _Òalculator;

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
        _Òalculator = new —alculatorExperiencePoint();
    }

    private void OnObjectCounted()
    {
        _countObjectCounted++;

        CheckImpactedObject();
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

    private void CheckImpactedObject()
    {
        if (_countObjectInLevel == _countObjectCounted)
        {
            //ÚÛÚ ÓÒÚ‡Ì‡‚ÎË‚ÂÚÒˇ Ë„‡ 
            _Òalculator.CalculateExperiencePoint(Time.time);
        }
    }
}
