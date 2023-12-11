using UnityEngine;

public class Focalization
{
    private float _focusDelay;
    private float _time;
    private Transform _target;
    private Transform _enemy;

    public bool TryAttack { get; private set; }

    public Focalization(float focusDelay, Transform enemy)
    {
        _focusDelay = focusDelay;
        _enemy = enemy;
    }

    public void Update()
    {
        if (IsFocusTarget())
        {
            TryAttack = true;
        }
        else
        {
            TryAttack = false;
        }
    }

    private bool IsFocusTarget()
    {
        if (_target == null)
            return false;

        _enemy.LookAt(_target);

        _time += Time.deltaTime;

        if (_time > _focusDelay)
        {
            _time = 0;
            return true;
        }

        return false;
    }


    public void SetTarget(Transform player)
    {
        Debug.Log("игрок был замечен противником");
        _target = player;
    }

    public void LoseTarget()
    {
        Debug.Log("игрок пропал у  противника");
        _target = null;
    }
}