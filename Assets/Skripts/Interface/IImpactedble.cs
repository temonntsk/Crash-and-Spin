using System;
using UnityEngine;

public interface IImpactedble
{
    public Rigidbody Rigidbody { get; }

    public void TakeImpact();
}