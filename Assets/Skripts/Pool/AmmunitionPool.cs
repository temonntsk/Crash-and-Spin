using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AmmunitionPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private float _capacityAmmunition;

    private List<Ammunition> _ammunitionPool = new List<Ammunition>();
    //сделать наследника который будет пользоваться типо будет пулл гранат и пулл патронов
    public Ammunition GiveAmmunition(Vector3 ammunitionPoint, Quaternion ammunitionRotation)
    {
        if (TryGetObject(out Ammunition ammunition))
        {
            ammunition.SetStartDirection(ammunitionPoint, ammunitionRotation);
            SetAmmunition(ammunition);

            return ammunition;
        }

        return null;
    }

    private void SetAmmunition(Ammunition ammunition)
    {
        ammunition.gameObject.SetActive(true);
    }

    public void CreateAmmunition(Ammunition prefab)
    {//это будет в родителе а остольное в наследниках 
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

    //
}