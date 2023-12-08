using UnityEngine;

public class GrenadeEnemyCombat : BaseCombat
{
    [SerializeField] private EnenyHand _hand;
    [SerializeField] private float _speed;
    [SerializeField] private int _countWayPoint;

    private WayPointsMovement _wayPoints;

    protected override void Awake()
    {
        base.Awake();

        _wayPoints = new WayPointsMovement(_countWayPoint, transform.position);
    }

    private void Update()
    {
        Focalization.Update();

        if (Focalization.TryAttack)
        {
            _hand.Throw(Target.position);
            ChangePosition();
        }
    }

    private void ChangePosition()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            _wayPoints.GetRandomWayPoint(), _speed * Time.deltaTime);
    }
}
