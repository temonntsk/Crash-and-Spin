using Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private MeleeWeapon _weapon;

    public void Attack()
    {
        _weapon.Attack();
        transform.Rotate(Vector3.up * Time.deltaTime * _rotationSpeed);
    }   
}
