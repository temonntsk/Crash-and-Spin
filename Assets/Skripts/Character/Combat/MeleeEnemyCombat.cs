using UnityEngine;

public class MeleeEnemyCombat : BaseCombat
{
    [SerializeField] private MeleeWeapon _weapon;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _speedApproach;

    private void Update()
    {
        Focalization.Update();

        if (Focalization.TryAttack)
        {
            _weapon.Attack();
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, _speedApproach * Time.deltaTime);
        transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.up);
    }
}