using System;
using UnityEngine;

public class IceSurface : MonoBehaviour
{
    private Vector3 _firstPosition;
    private Vector3 _secondPosition;

    public void TakeSecondPosition(Vector3 vector)
    {
        _secondPosition = vector;

    }

    public void TakeFirstPosition(Vector3 vector)
    {
        _firstPosition = vector;
    }

    public Vector3 CreateDirection()
    {
        Vector3 direction = _secondPosition - _firstPosition;

        return direction.normalized;
    }
}
