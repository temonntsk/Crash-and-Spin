using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    [SerializeField] private float _force;

    private AppliedForce _appliedForce;

    private void Awake()
    {
        _appliedForce = new AppliedForce(_force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DestructibleWall destructibleWall))
        {
            destructibleWall.Break();
        }
        // TODO: пределать в один иф
        if (other.TryGetComponent(out BrokenWall brokenWall))
        {
            var rigidbody = brokenWall.GetComponent<Rigidbody>();

            _appliedForce.HitTarget(rigidbody, transform.position);
        }
    }
}
