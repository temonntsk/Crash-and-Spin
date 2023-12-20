using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BrokenWall : MonoBehaviour, IImpactedble
{
    private const float _force = 1f;

    private AppliedForce _appliedForce;
    private Rigidbody _rigidbody;
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
        if (_isFirstImpact)
        {
            _isFirstImpact = false;
        }
        //выделение очков для прокачки игрока
    }
}
