using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BodyEnemy : MonoBehaviour, IImpacted,IFalling
{
    [SerializeField] private EnemyHealth _health;

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
        _health.Die();
    }

    public void Fall()
    {
        //пока не реализовано 
    }
}
