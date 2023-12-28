using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class BrokenWall : MonoBehaviour, IImpactedble, IExplodable
{
    //избавиться от меш колайдеров и постатвь обычные кубики и сферы
    private const float _force = 1f;

    private Rigidbody _rigidbody;
    private bool _isFirstImpact;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IImpactedble impactedObject))
        {
            impactedObject.TakeImpact(transform.position,_force);
        }
    }

    public void TakeImpact(Vector3 touchingPosition,float forceImpact)
    {
        if (_isFirstImpact)
        {
            ApplyImpact(touchingPosition, forceImpact);
            _isFirstImpact = false;
        }
    }

    private void ApplyImpact(Vector3 touchingPosition, float forceImpact)
    {
        var direction = transform.position - touchingPosition;
        _rigidbody.AddForce(direction * forceImpact, ForceMode.Impulse);
    }

    public void TakeExplosion(float explosionForce, Vector3 position, float explosionRadius)
    {
        _rigidbody.AddExplosionForce(explosionForce, position, explosionRadius);
    }
}
