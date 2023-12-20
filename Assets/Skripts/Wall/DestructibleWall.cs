using System;
using UnityEngine;

public class DestructibleWall : MonoBehaviour, IImpactedble, ICountble
{
    [SerializeField] private BrokenWall _brokenWall;

    private Rigidbody _rigidbody;
    private bool _isFirstImpact = true;

    public event Action ObjectCounted;

    public Rigidbody Rigidbody => _rigidbody;

    public bool IsFirstImpact => _isFirstImpact;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); ;
    }

    public void TakeImpact()
    {
        if (_isFirstImpact)
        {
            Instantiate(_brokenWall, transform.position, transform.rotation);
            ObjectCounted?.Invoke();
            gameObject.SetActive(false);
            _isFirstImpact = false;
        }
    }
}
