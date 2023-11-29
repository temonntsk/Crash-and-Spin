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
        _target = player;
        _isTargetSet = true;
    }

    public void ResetAttack()
    {
        _isTargetSet = false;
        _target = null;
    }
}