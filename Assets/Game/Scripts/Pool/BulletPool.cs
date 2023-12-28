using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private float _capacityBullets;

    private List<Bullet> _bulletPool = new List<Bullet>();

    public void CreateBullet(Bullet prefab)
    {
        for (int i = 0; i < _capacityBullets; i++)
        {
            Bullet spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _bulletPool.Add(spawned);
        }
    }

    public void ActiveBullet(Vector3 bulletPoint, Quaternion bulletRotation)
    {
        if (TryGetObject(out Bullet bullet))
        {
            bullet.SetStartDirection(bulletPoint, bulletRotation);
            SetAmmunition(bullet);
        }
    }

    private void SetAmmunition(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private bool TryGetObject(out Bullet bullet)
    {
        bullet = _bulletPool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return bullet != null;
    }
}