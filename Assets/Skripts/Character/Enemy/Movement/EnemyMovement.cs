using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour, ISlippinble
{
    [SerializeField] protected float Speed;

    private Vector3 _directionIceSurface;

    public bool IsOnSlippined { get; set; }

    public Vector3 FirstPosition => transform.position;
    public Vector3 SecondPosition => transform.position;

    private void Update()
    {
        if (IsOnSlippined)
        {
            Move(_directionIceSurface);
        }
    }

    public virtual void Move(Vector3 direction){ }

    public void TakeSlippinedDirection(Vector3 slippinedDirection)
    {
        _directionIceSurface = slippinedDirection;
    }
}
