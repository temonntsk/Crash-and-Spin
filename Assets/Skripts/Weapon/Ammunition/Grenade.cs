using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Ammunition
{
    [SerializeField] private float _speed;

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        //тут сделать полет по касательной
    }
}
