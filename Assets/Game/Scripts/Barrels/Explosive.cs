using System.Collections.Generic;
using UnityEngine;

public class Explosive
{
    private readonly float _explosionRadius;
    private readonly float _explosionForce;

    public Explosive(float explosionRadius, float explosionForce)
    {
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
    }

    public void Explode(Vector3 explosionPosition)
    {
        List<IExplodable> explosionbleObjects = GetExplosionbleObjects( explosionPosition);

        foreach (IExplodable explosionbleObject in explosionbleObjects)
        {
            explosionbleObject.TakeExplosion(_explosionForce, explosionPosition, _explosionRadius);
        }
    }

    private List<IExplodable> GetExplosionbleObjects(Vector3 explosionPosition)
    {
        Collider[] hits = Physics.OverlapSphere(explosionPosition, _explosionRadius);

        List<IExplodable> barrels = new List<IExplodable>();

        foreach (var hit in hits)
            if (hit.TryGetComponent(out IExplodable explosionbleObject))
            {
                barrels.Add(explosionbleObject);
            }

        return barrels;
    }
}
