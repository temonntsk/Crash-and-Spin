using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Barrel : MonoBehaviour, IImpactedble
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    //[SerializeField] private ParticleSystem _effect;

    private Explosive _explosive;

    private void Start()
    {
        _explosive = new Explosive(_explosionRadius, _explosionForce);
    }

    public void TakeImpact(Vector3 touchingPosition, float forceImpact)
    {
        _explosive.Explode(transform.position);
        Destroy(gameObject);
    }
}
