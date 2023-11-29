using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AmmunitionPool))]
public class GrenadeWeapon : Weapon
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Grenade _prefab;

    private Vector3 _positionTarget;
    private bool _isTakePositionTarget;
    private AmmunitionPool _pool;


    private void Awake()
    {
        _pool.Initialize(_prefab);
    }

    private void Throw()
    {
        if (_isTakePositionTarget)
        {
            _prefab.GiveDropPoint(_positionTarget);
            _pool.SpawnAmmunition(_shootPoint.position, _shootPoint.rotation);
        }
    }

    public void Aim(Vector3 positionTarget)
    {
        _positionTarget = positionTarget;
        _isTakePositionTarget = true;
    }

    public override void Attack() => Throw();
}
