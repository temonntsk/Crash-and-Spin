using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyCombat : BaseCombat
{
    [SerializeField] private MeleeWeapon _weapon;
    [SerializeField] private float _speedApproach;

    private void Update()
    {
        Focalization.Update();

        if (Focalization.TryAttack)
        {
            _weapon.Attack();
            ActiveAttack = true;
        }

        if (CanMoveToTarget())
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, _speedApproach * Time.deltaTime);
    }

    private bool CanMoveToTarget()
    {
        if (Target == null)
        {
            ActiveAttack = false;

            return false;
        }
        else if (ActiveAttack)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}