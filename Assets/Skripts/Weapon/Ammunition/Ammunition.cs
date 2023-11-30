using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    [SerializeField] private float _force;

    private AppliedForce _appliedForce;

    private void Awake()
    {
        _appliedForce = new AppliedForce(_force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IImpacted impactedObject))
        {
            impactedObject.TakeImpact();

            Rigidbody targetBody = impactedObject.Rigidbody;
            _appliedForce.HitTarget(targetBody, transform.position);
        }
    }

    public void SetPosition(Vector3 spawnPoint,Quaternion spawnRotation)//назвать правильно
    {
        transform.position = spawnPoint;
        transform.rotation = spawnRotation;
    }
}
