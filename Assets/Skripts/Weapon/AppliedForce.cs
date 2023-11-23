using UnityEngine;
using UnityEngine.UIElements;

public abstract class AppliedForce : MonoBehaviour
{
    [SerializeField] private float _impactForce;

    protected void HitTarget(Rigidbody rigidbody)
    {
        var direction = rigidbody.transform.position - transform.position;

        rigidbody.AddForce(direction * _impactForce, ForceMode.Impulse);
    }
}
