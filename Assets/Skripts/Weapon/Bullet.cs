using UnityEngine;

public class Bullet :MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _speed;

    private AppliedForce _appliedForce;

    private void Awake()
    {
        _appliedForce = new AppliedForce(_force);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DestructibleWall destructibleWall))
        {
            destructibleWall.Break();
        }
        // TODO: пределать в один иф
        if (other.TryGetComponent(out BrokenWall brokenWall))
        {
            var rigidbody = brokenWall.GetComponent<Rigidbody>();

            _appliedForce.HitTarget(rigidbody, transform.position);
        }
    }

}
