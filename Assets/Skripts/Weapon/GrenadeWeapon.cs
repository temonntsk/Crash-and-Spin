using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AmmunitionPool))]
public class GrenadeWeapon : Weapon//энами хенд и он не будет наследовать 
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Grenade _prefab;

    private Vector3 _positionTarget;
    private bool _isTakePositionTarget;
    private AmmunitionPool _pool;


    private void Awake()
    {
        _pool = GetComponent<AmmunitionPool>();

        if (_pool != null)
            _pool.CreateAmmunition(_prefab);
    }

    private void Throw()
    {
        if (_isTakePositionTarget)
        {
            var grenade = _pool.GiveAmmunition(_shootPoint.position, _shootPoint.rotation);
            grenade.GetComponent<Grenade>().TakeDropPoint(_positionTarget);
           // grenade.TakeDropPoint(_positionTarget);
        }
    }

    public void Aim(Vector3 positionTarget)
    {
        _positionTarget = positionTarget;
        _isTakePositionTarget = true;
    }

    public override void Attack() => Throw();
}
