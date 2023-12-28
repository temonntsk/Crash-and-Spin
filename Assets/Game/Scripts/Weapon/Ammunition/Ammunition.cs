using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] protected float Force;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IImpactedble impactedObject))
        {
            impactedObject.TakeImpact(transform.position,Force);
            gameObject.SetActive(false);
        }
    }

    public void SetStartDirection(Vector3 spawnPoint, Quaternion spawnRotation)
    {
        transform.position = spawnPoint;
        transform.rotation = spawnRotation;
    }
}