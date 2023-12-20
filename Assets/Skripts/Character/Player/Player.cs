using Movement;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;

    private PlayerCombat _combat;
    private PlayerMovement _movement;
    private PlayerParameters _stats;

    private void Awake()
    {
        _stats = new PlayerParameters();
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
        _health.TakeHealth(_stats.MaxHealth);
        _combat.TakeRotationSpeed(_stats.RotationSpeed);
        _combat.TakeForceForWeapon(_stats.WeaponForce);
        _movement.TakeSpeed(_stats.MovementSpeed);
    }
}
