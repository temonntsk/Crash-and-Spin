using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BodyEnemy : MonoBehaviour, IImpactedble,IFallingble,ICountble
{
    private const float _force = 1f;

    [SerializeField] private EnemyHealth _health;

    private Rigidbody _rigidbody;
    private AppliedForce _appliedForce;
    private bool _isFirstImpact = true;

    public event Action ObjectCounted;

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
        if (_isFirstImpact)
        {
            _health.Die();
            ObjectCounted.Invoke();
            _isFirstImpact = false;
        }
    }

    public void Fall()
    {
        _health.Die();
    }
}
