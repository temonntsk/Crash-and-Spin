using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    //[SerializeField] private ParticleSystem _effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IImpactedble impactedObject))
        {
            Explode();
        }

    }

    private void Explode()
    {
        foreach (Rigidbody explosionbleObject in GetExplosionbleObjects())
        {
            explosionbleObject.AddExplosionForce(_explosionForce,transform.position,_explosionRadius);
        }
    }

    private List<Rigidbody> GetExplosionbleObjects()
    {
        Collider[] hits= Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> barrels = new List<Rigidbody>();

        foreach (var hit in hits)
            if(hit.attachedRigidbody != null)
                barrels.Add(hit.attachedRigidbody);

        return barrels;
    }

}
