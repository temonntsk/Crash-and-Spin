using UnityEngine;

public class GrenadeEnemyCombat : BaceCombat
{
    [SerializeField] private float _speed;
    [SerializeField] private int _countWayPoint;

    private WayPointsMovement _wayPoints;
    private GrenadeWeapon _grenadeWeapon = new GrenadeWeapon();
    private Vector3 _position;

    private void Awake()
    {
        _position = transform.position;
        _wayPoints = new WayPointsMovement(_countWayPoint, _position);
        Weapon = new GrenadeWeapon();//это не правильно //сделать отдельным классом 
        _grenadeWeapon = Weapon as GrenadeWeapon;
    }

    protected override void Attack()
    {
        if (_grenadeWeapon is GrenadeWeapon)
            _grenadeWeapon.Aim(Target.position);

        base.Attack();
        ChangePosition();
    }

    private void ChangePosition()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            _wayPoints.GetRandomWayPoint(), _speed * Time.deltaTime);
    }
}
