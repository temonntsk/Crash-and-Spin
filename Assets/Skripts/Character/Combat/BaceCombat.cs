using UnityEngine;

public class BaceCombat : MonoBehaviour
{
    //���� ������ (�������� �������� �� ��� ����� ������ )
    //  BaceCombat ������� ����������� 

    [SerializeField] protected Weapon Weapon;
    [SerializeField] private float _focusDelay;

    protected Transform Target;
    private float _time;
    private bool _isTargetSet;

    private void Update()
    {
        if (_isTargetSet)
        {
            if (IsFocusTarget())
            {
                print("�������");
                Attack();
            }
        }
    }

    private bool IsFocusTarget()
    {
        transform.LookAt(Target);

        _time += Time.deltaTime;

        if (_time > _focusDelay)
        {
            _time = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual void Attack()
    {
        Weapon.Attack();
    }

    public void SetTarget(Transform player)
    {
        print("����� ��� ������� �����������");
        Target = player;
        _isTargetSet = true;
    }

    public void LoseTarget()
    {
        print("����� ������ �  ����������");
        _isTargetSet = false;
        Target = null;
    }
}