using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] protected Weapon _weapon;
    [SerializeField] private float _focusDelay;

    protected Transform _target;
    private float _time;
    private bool _isTargetSet;

    private void Update()
    {
        if (_isTargetSet)
        {
            if (IsFocusTarget())
            {
                print("выстрел");
                Attack();
            }
        }
    }

    private bool IsFocusTarget()
    {
        transform.LookAt(_target);

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
        _weapon.Attack();
    }

    public void PrepareAttack(Transform player)
    {
        print("игрок был замечен противником");
        _target = player;
        _isTargetSet = true;
    }

    public void ResetAttack()
    {
        print("игрок пропал у  противника");
        _isTargetSet = false;
        _target = null;
    }
}