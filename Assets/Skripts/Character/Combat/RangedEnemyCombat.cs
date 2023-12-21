using UnityEngine;

public class RangedEnemyCombat : BaseCombat
{
    [SerializeField] private RangedWeapon _rangedWeapon;
    [SerializeField] private RangedEnemyMovement _movement;

    private void Update()
    {
        Focalization.Update();

        if (Focalization.TryAttack)
        {
            _rangedWeapon.Shoot();
            ActiveAttack = true;
        }

        if (Target == null)
        {
            ActiveAttack = false;
        }
    }
}

