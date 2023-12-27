using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BodyEnemy : MonoBehaviour, IImpactedble, IFallingble, IExplodable,ICountble
{
    private const float _force = 1f;

    private EnemyHealth _health;
    private Rigidbody _rigidbody;
    private bool _isFirstImpact = true;

    public event Action ObjectCounted;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _health = new EnemyHealth();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IImpactedble impactedObject))
        {
            impactedObject.TakeImpact(transform.position,_force);
        }
    }

    public void TakeImpact(Vector3 touchingPosition, float forceImpact)
    {

            Die();
            //регдольная кукула так же будет принимать ApplyImpact(Vector3 touchingPosition, float forceImpact)
            _isFirstImpact = false;
        
    }

    public void Fall()
    {
        Die();
    }

    public void TakeExplosion(float explosionForce, Vector3 position, float explosionRadius)
    {
        Die();
        _rigidbody.AddExplosionForce(explosionForce, position, explosionRadius);
    }

    private void Die()
    {
        if (_isFirstImpact)
        {
            _health.Die();//жизней и так нет как заменить регдольной кукулой 
            ObjectCounted?.Invoke();
            //регдольная кукула включилась
            _isFirstImpact = false;
        }
    }
}
