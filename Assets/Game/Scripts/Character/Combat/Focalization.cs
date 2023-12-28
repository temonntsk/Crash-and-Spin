using UnityEngine;

public class Focalization
{
    private readonly float _focusDelay;
    private float _time;
    private Transform _target;
    private readonly Transform _enemy;

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
        if (_time > 0 && _target == null)
            _time -= Time.deltaTime;

        if (_target == null)
            return false;

        _enemy.LookAt(_target);

        _time += Time.deltaTime;

        if (_time > _focusDelay)
        {
            return true;
        }

        return false;
    }

    public void SetTarget(Transform player)
    {
        _target = player;
    }

    public void LoseTarget()
    {
        _target = null;
    }
}