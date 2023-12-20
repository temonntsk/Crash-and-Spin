using System;
using UnityEngine;
using UnityEngine.WSA;

[RequireComponent(typeof(Rigidbody))]
public class BodyPlayer : MonoBehaviour, IImpactedble, IFallingble
{
    private const float _force = 1f;

    [SerializeField] private PlayerHealth _health;

    private Rigidbody _rigidbody;
    private AppliedForce _appliedForce;
    private bool _isFirstImpact;

    public Rigidbody Rigidbody => _rigidbody;

    public bool IsFirstImpact => _isFirstImpact;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _appliedForce = new AppliedForce(_force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IImpactedble impactedObject))
        {
            impactedObject.TakeImpact();

            Rigidbody targetBody = impactedObject.Rigidbody;
            _appliedForce.HitTarget(targetBody, transform.position);
        }
    }

    public void TakeImpact()
    {
        if (_isFirstImpact || _health.IsDead == false)
        {
            //тут будет включение риджет бади или еще как то что бы работало 
            _health.TakeDamage();
            _isFirstImpact = false;
        }
    }

    public void Fall()
    {
        while (_health.IsDead == false)
        {
            _health.TakeDamage();
        }
    }
}
