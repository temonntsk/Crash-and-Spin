using UnityEngine;

public class MeleeEnemyCombat : BaceCombat
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _speedApproach;
    
    protected override void Attack()
    {
        base.Attack();
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, _speedApproach * Time.deltaTime);
        transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.up);
    }
}