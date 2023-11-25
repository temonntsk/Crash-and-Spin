using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] private float _force;

    private AppliedForce _appliedForce;

    private void Awake()
    {
        _appliedForce = new AppliedForce(_force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DestructibleWall destructibleWall))
        {
            destructibleWall.Break();
        }

        if (other.TryGetComponent(out BrokenWall brokenWall))
        {
            var rigidbody = brokenWall.GetComponent<Rigidbody>();

            _appliedForce.HitTarget(rigidbody, transform.position);
        }
    }
}
