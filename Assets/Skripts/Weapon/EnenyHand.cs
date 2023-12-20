using UnityEngine;

[RequireComponent(typeof(GrenadePool))]
public class EnenyHand : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Grenade _prefab;

    private GrenadePool _pool;

    private void Start()
    {
        _pool = GetComponent<GrenadePool>();

        if (_pool != null)
            _pool.CreateGrenade(_prefab);
    }

    public void Throw(Vector3 positionTarget)
    {
        var grenade = _pool.GiveGrenade(_shootPoint.position, _shootPoint.rotation);

        if (grenade != null)
            grenade.TakeDropPoint(positionTarget);
    }
}
