using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerDetecter _detecter;
    private Transform _target;

    private void Awake()
    {
        _detecter = GetComponentInChildren<PlayerDetecter>();
    }

    private void OnEnable()
    {
        _detecter.PlayerFound += OnPlayerFound;
    }

    private void OnDisable()
    {
        _detecter.PlayerFound -= OnPlayerFound;
    }

    private void Update()
    {
        if (_target != null)
        {
            transform.LookAt(_target);
        }
    }

    private void Attack()
    {

    }

    private void Die()
    {

    }

    private void OnPlayerFound(Player player)
    {
        if (player != null)
        {
            _target = player.transform;
        }
    }
}
