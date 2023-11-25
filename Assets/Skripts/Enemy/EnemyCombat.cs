using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private RangedWeapon _weapon;

    public void Attack()
    {
        print("атакует");
       _weapon.Shoot();
    }
}
