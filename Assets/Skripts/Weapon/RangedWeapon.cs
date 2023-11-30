using UnityEngine;

[RequireComponent(typeof(AmmunitionPool))]
public class RangedWeapon : Weapon
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _prefab;

    private AmmunitionPool _pool;

    private void Start()
    {
        _pool = GetComponent<AmmunitionPool>();

        if (_pool != null)
            _pool.CreateAmmunition(_prefab);
    }

    private void Shoot()
    {
        _pool.ActivateAmmunition(_shootPoint.position, _shootPoint.rotation);
    }

    public override void Attack() => Shoot();
}
