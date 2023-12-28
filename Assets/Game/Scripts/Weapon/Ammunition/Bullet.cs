using UnityEngine;

public class Bullet : Ammunition
{
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}