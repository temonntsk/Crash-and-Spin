using System;
using UnityEngine;
using UnityEngine.UIElements;

public class DestructibleWall : MonoBehaviour, IImpactedble, ICountble, IExplodable
{
    [SerializeField] private BrokenWall[] _brokenWalls;

    private bool _isFirstImpact = true;

    public event Action ObjectCounted;

    private void Start()
    {
        foreach (var brokenWall in _brokenWalls)
        {
            brokenWall.gameObject.SetActive(false);
        }
    }

    public void TakeImpact(Vector3 touchingPosition, float forceImpact)
    {
        if (_isFirstImpact)
        {
            Destruction();
            _isFirstImpact = false;
        }
    }

    public void TakeExplosion(float explosionForce, Vector3 position, float explosionRadius)
    {
        Destruction();

        foreach (var brokenWall in _brokenWalls)
        {
            brokenWall.TakeExplosion(explosionForce, position, explosionRadius);
        }
    }

    private void Destruction()
    {
        gameObject.SetActive(false);

        foreach (var brokenWall in _brokenWalls)
        {
            brokenWall.gameObject.SetActive(true);
        }

        ObjectCounted?.Invoke();
    }
}
