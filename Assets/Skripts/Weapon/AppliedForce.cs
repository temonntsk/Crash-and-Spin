using UnityEngine;

public class AppliedForce
{
    private readonly float _impactForce;
    private readonly float _minImpactForce = 0;

    public AppliedForce(float impactForce)
    {
        if (impactForce <= _minImpactForce)
            _impactForce = ++_minImpactForce;

        _impactForce = impactForce;
    }

    public void HitTarget(Rigidbody rigidbody, Vector3 touchingPosition)
    {
        var direction = rigidbody.transform.position - touchingPosition;
        rigidbody.AddForce(direction * _impactForce, ForceMode.Impulse);
    }
}