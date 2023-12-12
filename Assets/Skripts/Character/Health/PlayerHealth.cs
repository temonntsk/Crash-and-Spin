using System;
using UnityEngine;

public class PlayerHealth : CharacterHealth
{
    [SerializeField] private int _health;

    private int _maxHealth;
    private readonly int _minHealth = 0;
    private readonly int _damage = 1;

    public bool IsDead => _health <= _minHealth;

    public event Action GameOver;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void TakeDamage()
    {
        _health = Mathf.Clamp(_health - _damage, _minHealth, _maxHealth);

        //тут изменение сердечка

        if (IsDead )
        {
            Die();
        }
    }

    private void Die()
    {
        print("Игрок умер");
        GameOver?.Invoke();
    }
}
