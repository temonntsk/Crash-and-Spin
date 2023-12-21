using Movement;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;

    private PlayerCombat _combat;
    private PlayerMovement _movement;
    private PlayerParameter _parameter;

    private void Awake()
    {
        _parameter = new PlayerParameter();
        _movement = GetComponent<PlayerMovement>();
        _combat = GetComponentInChildren<PlayerCombat>();
        PassValueFromStat();
    }

    private void FixedUpdate()
    {
        if(_movement.IsMoved)
        {
            _combat.Attack();
        }
    }

    private void PassValueFromStat()
    {
        _health.TakeHealth(_parameter.MaxHealth);
        _combat.TakeRotationSpeed(_parameter.RotationSpeed);
        _combat.TakeForceForWeapon(_parameter.WeaponForce);
        _movement.TakeSpeed(_parameter.MovementSpeed);
    }
}
