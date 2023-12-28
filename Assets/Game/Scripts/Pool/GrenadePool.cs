using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GrenadePool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private float _capacityGrenades;

    private List<Grenade> _grenadePool = new List<Grenade>();

    public void CreateGrenade(Grenade prefab)
    {
        for (int i = 0; i < _capacityGrenades; i++)
        {
            Grenade grenade = Instantiate(prefab, _container.transform);
            grenade.gameObject.SetActive(false);

            _grenadePool.Add(grenade);
        }
    }

    public Grenade GiveGrenade(Vector3 grenadePoint, Quaternion grenadeRotation)
    {
        if (TryGetObject(out Grenade grenade))
        {
            grenade.SetStartDirection(grenadePoint, grenadeRotation);
            SetAmmunition(grenade);

            return grenade;
        }

        return null;
    }

    private void SetAmmunition(Grenade grenade)
    {
        grenade.gameObject.SetActive(true);
    }

    private bool TryGetObject(out Grenade grenade)
    {
        grenade = _grenadePool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return grenade != null;
    }
}

