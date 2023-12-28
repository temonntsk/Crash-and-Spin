using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] protected float Force;//������ ��� �� � ������ � � ����� ������ ����� ()

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