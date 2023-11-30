using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AmmunitionPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private float _capacityAmmunition;

    private List<Ammunition> _ammunitionPool = new List<Ammunition>();//переназвать с более конректной объектов

    public void ActivateAmmunition(Vector3 ammunitionPoint, Quaternion ammunitionRotation)
    {
        if (TryGetObject(out Ammunition ammunition))
        {
            ammunition.SetPosition(ammunitionPoint, ammunitionRotation);
            SetAmmunition(ammunition);
        }
    }

    private void SetAmmunition(Ammunition ammunition)
    {
        ammunition.gameObject.SetActive(true);
    }

    public void CreateAmmunition(Ammunition prefab)
    {
        for (int i = 0; i < _capacityAmmunition; i++)
        {
            Ammunition spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _ammunitionPool.Add(spawned);
        }
    }

    private bool TryGetObject(out Ammunition result)
    {
        result = _ammunitionPool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}