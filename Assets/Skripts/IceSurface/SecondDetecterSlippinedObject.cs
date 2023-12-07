using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDetecterSlippinedObject : MonoBehaviour
{
    [SerializeField] private IceSurface _iceSurface;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ISlippined slippined))
        {
            slippined.IsOnSlippined = true;
            _iceSurface.TakeSecondPosition(slippined.SecondPosition);
            slippined.TakeSlippinedDirection(_iceSurface.CreateDirection());
        }
    }
}
