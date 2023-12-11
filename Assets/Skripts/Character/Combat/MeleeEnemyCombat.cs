using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyCombat : BaseCombat
{
    [SerializeField] private MeleeWeapon _weapon;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _speedApproach;

    private bool _activeAttack;

    private void Update()
    {
        Focalization.Update();

        if (Focalization.TryAttack)
        {
            _weapon.Attack();
            _activeAttack = true;
        }

        if (CanMoveToTarget())
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, _speedApproach * Time.deltaTime);
        transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.up);//тут будет просто анимация кружения
    }

    private bool CanMoveToTarget()
    {
        if (Target == null)
        {
            _activeAttack = false;
            return false;
        }
        else if (_activeAttack)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}