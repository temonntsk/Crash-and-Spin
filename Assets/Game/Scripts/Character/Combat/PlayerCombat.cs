using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerMeleeWeapon _weapon;

    private float _rotationSpeed;
    private float _minRotationSpeed;
     

    public void Attack()
    {
        _weapon.Attack();
        transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.up);
    }

    public void TakeRotationSpeed(float rotationSpeed)
    {
        if (rotationSpeed <= _minRotationSpeed)
        {
            _rotationSpeed = ++_minRotationSpeed;
        }

        _rotationSpeed = rotationSpeed;
    }

    public void TakeForceForWeapon(float force)
    {
        _weapon.TakeForce(force);
    }
}
