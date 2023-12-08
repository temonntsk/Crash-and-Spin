using UnityEngine;

[RequireComponent(typeof(BulletPool))]
public class RangedWeapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _prefab;

    private BulletPool _pool;

    private void Start()
    {
        _pool = GetComponent<BulletPool>();

        if (_pool != null)
            _pool.CreateBullet(_prefab);
    }

    public void Shoot()
    {
        _pool.ActiveBullet(_shootPoint.position, _shootPoint.rotation);
    }
}
