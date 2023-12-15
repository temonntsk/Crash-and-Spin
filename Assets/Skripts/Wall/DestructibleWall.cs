using System;
using UnityEngine;

public class DestructibleWall : MonoBehaviour, IImpactedble,ICountble
{
    [SerializeField] private BrokenWall _brokenWall;

    private Rigidbody _rigidbody;

    public event Action ObjectCounted;

    public Rigidbody Rigidbody => _rigidbody;

    private void Start()
    {
        _rigidbody= GetComponent<Rigidbody>();;
    }

    public void TakeImpact()
    {
        Instantiate(_brokenWall, transform.position, transform.rotation);
        ObjectCounted?.Invoke();
        gameObject.SetActive(false);
    }
}
