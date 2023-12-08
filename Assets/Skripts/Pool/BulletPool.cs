using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private float _capacityAmmunition;

    private List<Bullet> _bulletPool = new List<Bullet>();

    public void CreateBullet(Bullet prefab)
    {
        for (int i = 0; i < _capacityAmmunition; i++)
        {
            Bullet spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _bulletPool.Add(spawned);
        }
    }

    public void ActiveBullet(Vector3 ammunitionPoint, Quaternion ammunitionRotation)
    {
        if (TryGetObject(out Bullet ammunition))
        {
            ammunition.SetStartDirection(ammunitionPoint, ammunitionRotation);
            SetAmmunition(ammunition);
        }
    }


    private void SetAmmunition(Bullet ammunition)
    {
        ammunition.gameObject.SetActive(true);
    }

    private bool TryGetObject(out Bullet result)
    {
        result = _bulletPool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}

