using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AmmunitionPool))]
public class RangedWeapon : Weapon
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _prefab;

    //тут сделать пулл патронов и при выстреле активизаровался один патрон из 5 патрон
    private AmmunitionPool _pool;

    private void Awake()
    {
        _pool.Initialize(_prefab);
    }

    private void Shoot()
    {
        _pool.SpawnAmmunition(_shootPoint.position, _shootPoint.rotation);
    }

    public override void Attack() => Shoot();
}
