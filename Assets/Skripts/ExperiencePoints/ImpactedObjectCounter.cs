using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactedObjectCounter : MonoBehaviour 
{
    //надо найти все объекты которые импактед и у которых булевая тру (типо не использованая) и
    //когда трекнет импакт сказать что буля станет фолс 

    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    private Collider[] _overLappedColliders = new Collider[50];

    public event Action<IImpacted> ResourceCellFound;

    public void Search()
    {
        Vector3 center = transform.position;
        Physics.OverlapSphereNonAlloc(center, _radius, _overLappedColliders, _layerMask);

        foreach (var collider in _overLappedColliders)
        {
            //if (collider == null)
            //{
            //    continue;
            //}

            //if (collider.TryGetComponent(out IImpacted resourceCell))
            //{
            //    if (!resourceCell.IsEmpty && !resourceCell.IsReserve)
            //    {
            //        ResourceCellFound?.Invoke(resourceCell);
            //        return;
            //    }
            //}
        }
    }

}
