using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] private float _force;

    private AppliedForce _appliedForce;

    private void Awake()
    {
        _appliedForce = new AppliedForce(_force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IImpactedble impactedObject))
        {
            impactedObject.TakeImpact();

            Rigidbody targetBody = impactedObject.Rigidbody;
            _appliedForce.HitTarget(targetBody, transform.position);

            gameObject.SetActive(false);
        }
    }

    public void SetStartDirection(Vector3 spawnPoint, Quaternion spawnRotation)
    {
        transform.position = spawnPoint;
        transform.rotation = spawnRotation;
    }
}