using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeEnemyCombat : EnemyCombat
{
    [SerializeField] private float _speed;
    [SerializeField] private int _countWayPoint;

    private WayPointsMovement _wayPoints;
    private GrenadeWeapon _grenadeWeapon = new GrenadeWeapon();

    private void Awake()
    {
        _wayPoints = new WayPointsMovement(_countWayPoint, transform.position);
        _weapon = new GrenadeWeapon();
        _grenadeWeapon = _weapon as GrenadeWeapon;
    }

    protected override void Attack()
    {
        if (_grenadeWeapon is GrenadeWeapon)
            _grenadeWeapon.Aim(_target.position);

        base.Attack();
        ChangePosition();
    }

    private void ChangePosition()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            _wayPoints.GetRandomWayPoint(), _speed * Time.deltaTime);
    }
}
