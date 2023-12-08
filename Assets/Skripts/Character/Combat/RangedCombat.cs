using UnityEngine;

public class RangedCombat : BaseCombat
{
    [SerializeField] private RangedWeapon _rangedWeapon;

    private void Update()
    {
        Focalization.Update();

        if (Focalization.TryAttack)
        {
            _rangedWeapon.Shoot();
        }
    }
}

