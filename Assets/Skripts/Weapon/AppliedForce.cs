using UnityEngine;

public class AppliedForce
{
    private readonly float _impactForce;

    public AppliedForce(float impactForce)
    {
        if (impactForce < 0)
            impactForce = 0;

        _impactForce = impactForce;
    }

    public void HitTarget(Rigidbody rigidbody,Vector3 touchingPosition)
    {
       var direction = rigidbody.transform.position - touchingPosition;
        rigidbody.AddForce(direction * _impactForce, ForceMode.Impulse);
    }
}