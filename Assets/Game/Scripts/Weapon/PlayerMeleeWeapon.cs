using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeWeapon : MeleeWeapon
{
    private float _minWeaponForce;

    public void TakeForce(float force)
    {
        if (force <= _minWeaponForce)
        {
            Force = ++_minWeaponForce;
        }

        Force = force;
    }
}
