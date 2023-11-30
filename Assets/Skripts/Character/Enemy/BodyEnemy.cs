using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BodyEnemy : MonoBehaviour, IImpacted
{
    private const float _force = 1f;
    private Rigidbody _rigidbody;
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
        //тут будет подсчет очков и вызов ивента что враг мертв
        //(будет система жизни либо в самом енеми подписываться что враг мертв) 
    }


}
