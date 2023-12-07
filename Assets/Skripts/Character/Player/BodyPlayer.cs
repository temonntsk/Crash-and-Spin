using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BodyPlayer : MonoBehaviour, IImpacted
{
    [SerializeField] private PlayerHealth _health;

    private Rigidbody _rigidbody;
    private const float _force = 1f;
    private AppliedForce _appliedForce;

    public Rigidbody Rigidbody => _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _appliedForce = new AppliedForce(_force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IImpacted impactedObject))
        {
            impactedObject.TakeImpact();

            Rigidbody targetBody = impactedObject.Rigidbody;
            _appliedForce.HitTarget(targetBody, transform.position);
        }
    }

    public void TakeImpact()
    {
        //тут будет включение риджет бади или еще как то что бы работало 
        _health.TakeDamage();
    }
}
