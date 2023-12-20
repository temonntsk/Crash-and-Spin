using System;
using UnityEngine;

public interface IImpactedble
{
    public Rigidbody Rigidbody { get; }

    public bool IsFirstImpact { get; }

    public void TakeImpact();
}