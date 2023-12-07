using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IImpacted
{
    public Rigidbody Rigidbody { get; }

    public void TakeImpact();
}
