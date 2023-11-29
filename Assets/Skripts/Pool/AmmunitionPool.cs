using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AmmunitionPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private float _capacityAmmunition;

    private List<Ammunition> _pool = new List<Ammunition>();

    public void SpawnAmmunition(Vector3 spawnPoint, Quaternion spawnRotation)
    {
        while (TryGetObject(out Ammunition ammunition))
        {
            SetAmmunition(ammunition, spawnPoint, spawnRotation);
        }
    }

    private void SetAmmunition(Ammunition ammunition, Vector3 spawnPoint, Quaternion spawnRotation)
    {
        ammunition.gameObject.SetActive(true);
        ammunition.transform.position = spawnPoint;
        ammunition.transform.rotation = spawnRotation;
    }

    public void Initialize(Ammunition prefab)
    {
        for (int i = 0; i < _capacityAmmunition; i++)
        {
            Ammunition spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    private bool TryGetObject(out Ammunition result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}