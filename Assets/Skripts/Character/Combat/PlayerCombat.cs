using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private MeleeWeapon _weapon;

    public void Attack()
    {
        _weapon.Attack();
        transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.up);
    }   
}
