using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MeleeCombat : EnemyCombat
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _speedApproach;

    private bool _isAttack = false;

    public override void Attack(Transform target)
    {
        base.Attack(target);
        _isAttack = true;
    }

    private void Update()
    {
        if (_isAttack)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speedApproach * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime * _rotationSpeed);
    }
}
