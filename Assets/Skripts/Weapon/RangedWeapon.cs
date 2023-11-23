using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : IShooting
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;
    //тут сделать пулл патронов и при выстреле активизаровался один патрон из 5 патрон  
    public void Shoot()
    {
        
    }
}
