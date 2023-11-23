using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _impactForce;
    //��� ���� �������� ��� �� ������ ����� �� ������ ��������� �� � ������ �������� � ���� ����������� ����� ���������

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DestructibleWall destructibleWall))
        {
            destructibleWall.Break();
        }

        if (other.TryGetComponent(out BrokenWall brokenWall))
        {
            var rigidbody = brokenWall.GetComponent<Rigidbody>();

            HitTarget(rigidbody);
        }
    }

    private void HitTarget(Rigidbody rigidbody)
    {
        var direction = rigidbody.transform.position - transform.position;

        rigidbody.AddForce(direction * _impactForce, ForceMode.Impulse);
    }
}
