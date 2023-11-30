using UnityEngine;

public class DestructibleWall : MonoBehaviour, IImpacted
{
    [SerializeField] private BrokenWall _brokenWall;

    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    private void Start()
    {
        _rigidbody= GetComponent<Rigidbody>();
    }

    public void TakeImpact()
    {
        Instantiate(_brokenWall, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
