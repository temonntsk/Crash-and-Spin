using UnityEngine;

public class FirstDetecterSlippinedObject : MonoBehaviour
{
    [SerializeField] private IceSurface _iceSurface;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ISlippinble slippined))
        {
            _iceSurface.TakeFirstPosition(slippined.FirstPosition);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ISlippinble slippinedObject))
        {
            slippinedObject.IsOnSlippined = false;
        }
    }
}