using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Ammunition _prefab;

    //тут сделать пулл патронов и при выстреле активизаровался один патрон из 5 патрон  
    private void Shoot()
    {
        Instantiate(_prefab, _shootPoint.position, _shootPoint.rotation);
    }

    public override void Attack() => Shoot();
}
