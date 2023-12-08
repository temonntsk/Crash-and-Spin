using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GrenadePool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private float _capacityAmmunition;

    private List<Grenade> _grenadePool = new List<Grenade>();

    public void CreateGrenade(Grenade prefab)
    {
        for (int i = 0; i < _capacityAmmunition; i++)
        {
            Grenade spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _grenadePool.Add(spawned);
        }
    }

    public Grenade GiveGrenade(Vector3 ammunitionPoint, Quaternion ammunitionRotation)
    {
        if (TryGetObject(out Grenade ammunition))
        {
            ammunition.SetStartDirection(ammunitionPoint, ammunitionRotation);
            SetAmmunition(ammunition);

            return ammunition;
        }

        return null;
    }

    private void SetAmmunition(Grenade ammunition)
    {
        ammunition.gameObject.SetActive(true);
    }

    private bool TryGetObject(out Grenade result)
    {
        result = _grenadePool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}

