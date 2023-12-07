using UnityEngine;

public interface ISlippined
{
    public bool IsOnSlippined { get; set; }

    public Vector3 FirstPosition { get; }
    public Vector3 SecondPosition { get; }

    public void TakeSlippinedDirection(Vector3 irection);
}
