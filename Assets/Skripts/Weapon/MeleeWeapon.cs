using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] protected float Force;//решить что бы у игрока и у враза разные даные ()

    private bool _isAttack;

    public override void Attack() => _isAttack = true;

    private void OnTriggerEnter(Collider other)
    {
        if (_isAttack)
        {
            if (other.TryGetComponent(out IImpactedble impactedObject))
            {
                impactedObject.TakeImpact(transform.position, Force);
            }
        }
    }
}