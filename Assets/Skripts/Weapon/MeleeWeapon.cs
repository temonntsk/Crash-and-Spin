using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : AppliedForce
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DestructibleWall destructibleWall))
        {
            destructibleWall.Break();
        }

        if (other.TryGetComponent(out BrokenWall brokenWall))
        {
            var rigidbody = brokenWall.GetComponent<Rigidbody>();

            HitTarget(rigidbody);
        }
    }
}
