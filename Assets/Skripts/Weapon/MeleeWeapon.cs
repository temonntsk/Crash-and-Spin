using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private float _force;

    private AppliedForce _appliedForce;
    private bool _isAttack;

    public override void Attack() => _isAttack = true;

    private void Awake()
    {
        _appliedForce = new AppliedForce(_force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isAttack)
        {
            if (other.TryGetComponent(out DestructibleWall destructibleWall))
            {
                destructibleWall.Break();
            }

            if (other.TryGetComponent(out BrokenWall brokenWall))
            {
                var targetBody = brokenWall.GetComponent<Rigidbody>();

                _appliedForce.HitTarget(targetBody, transform.position);
            }
        }
    }
}