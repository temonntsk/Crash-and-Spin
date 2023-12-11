using UnityEngine;

public class GrenadeEnemyCombat : BaseCombat
{
    [SerializeField] private EnenyHand _hand;
    [SerializeField] private float _speed;
    [SerializeField] private int _countWayPoint;

    private WayPointsMovement _wayPoints;
    private Vector3 _newPoint;

    protected override void Awake()
    {
        base.Awake();

        _wayPoints = new WayPointsMovement(_countWayPoint, transform.position);
        _newPoint = transform.position;
    }

    private void Update()
    {
        Focalization.Update();

        if (Focalization.TryAttack)
        {
            _hand.Throw(Target.position);
            ChangeWayPoint();
        }

        Move();
    }

    private void Move()
    {
        if (transform.position != _newPoint)
            transform.position = Vector3.MoveTowards(transform.position, _newPoint, _speed * Time.deltaTime);
    }

    private void ChangeWayPoint()
    {
        _newPoint = _wayPoints.GetRandomWayPoint();
    }
}
