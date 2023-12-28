using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExplodable
{
    void TakeExplosion(float explosionForce, Vector3 position, float explosionRadius);
}