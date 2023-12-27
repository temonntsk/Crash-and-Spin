using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BodyPlayer : MonoBehaviour, IImpactedble, IFallingble
{
    private const float _force = 1f;

    private PlayerHealth _health;
    private Rigidbody _rigidbody;
    private bool _isFirstImpact = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _health = new PlayerHealth();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IImpactedble impactedObject))
        {
            impactedObject.TakeImpact(transform.position, _force);
        }
    }

    public void Fall()
    {
        while (_health.IsDead == false)
        {
            _health.TakeDamage();
        }
    }

    public void TakeImpact(Vector3 touchingPosition, float forceImpact)
    {
        if (_isFirstImpact || _health.IsDead == false)
        {
            //тут будет включение риджет бади или еще как то что бы работало 
            //регдол кукла будет принимать вот этот импульс
            ApplyImpact(touchingPosition, forceImpact);
            _health.TakeDamage();
            _isFirstImpact = false;
        }
    }

    private void ApplyImpact(Vector3 touchingPosition, float forceImpact)
    {
        var direction = transform.position - touchingPosition;
        _rigidbody.AddForce(direction * forceImpact, ForceMode.Impulse);
    }
}
