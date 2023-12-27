using UnityEngine;

public class GrenadeEnemyCombat : BaseCombat
{
    [SerializeField] private EnenyHand _hand;
    [SerializeField] private int _countWayPoint;
    [SerializeField] private GrenadeEnemyMovement _movement;

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
            ActiveAttack = true;
        }

        if (Target == null)
        {
            ActiveAttack = false;
        }

        _movement.Move(_newPoint);
    }

    private void ChangeWayPoint()
    {
        _newPoint = _wayPoints.GetRandomWayPoint();
    }
}
