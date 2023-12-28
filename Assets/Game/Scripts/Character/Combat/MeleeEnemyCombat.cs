using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyCombat : BaseCombat
{
    [SerializeField] private MeleeWeapon _weapon;
    [SerializeField] private MeleeEnemyMovement _movement;

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
            _movement.Move(Target.position);
        }
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