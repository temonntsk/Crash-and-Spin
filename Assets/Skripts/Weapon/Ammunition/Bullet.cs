using UnityEngine;

public class Bullet : Ammunition
{
    [SerializeField] private float _speed;

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}