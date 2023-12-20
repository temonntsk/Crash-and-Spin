using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] protected float Force;

    private AppliedForce _appliedForce;
    private bool _isAttack;

    public override void Attack() => _isAttack = true;

    private void Start()
    {
        _appliedForce = new AppliedForce(Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isAttack)
        {
            if (other.TryGetComponent(out IImpactedble impactedObject))
            {
                impactedObject.TakeImpact();

                Rigidbody targetBody = impactedObject.Rigidbody;
                _appliedForce.HitTarget(targetBody, transform.position);
            }
        }
    }
}