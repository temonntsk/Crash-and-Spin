using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Ammunition _prefab;

    //��� ������� ���� �������� � ��� �������� ��������������� ���� ������ �� 5 ������  
    private void Shoot()
    {
        Instantiate(_prefab, _shootPoint.position, _shootPoint.rotation);
    }

    public override void Attack() => Shoot();
}
