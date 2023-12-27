using System;
using UnityEngine;

public class PlayerHealth
{
    private float _health;
    private float _minHealth;

    public bool IsDead => _health <= _minHealth;

    public event Action GameOver;

    public void TakeHealth(float health)
    {
        if (health <= _minHealth)
        {
            _health = ++_minHealth;
        }

        _health = health;
    }

    public void TakeDamage()
    {
       _health--;

        //тут изменение сердечка

        if (IsDead)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Игрок умер");
        GameOver?.Invoke();
    }
}
