using System;
using UnityEngine;
using UnityEngine.WSA;

public class FirstDetecterSlippinedObject : MonoBehaviour
{

    [SerializeField] private IceSurface _iceSurface;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ISlippined slippined))
        {
            _iceSurface.TakeFirstPosition(slippined.FirstPosition);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ISlippined slippinedObject))
        {
            slippinedObject.IsOnSlippined = false;
        }
    }
}


