using UnityEngine;

[RequireComponent(typeof(PlayerDetecter))]
[RequireComponent(typeof(BodyEnemy))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private BaceCombat _combat;

    private PlayerDetecter _detecter;
    private BodyEnemy _bodyEnemy;

    private void Awake()
    {
        _bodyEnemy = GetComponent<BodyEnemy>();
        _detecter = GetComponentInChildren<PlayerDetecter>();
    }

    private void OnEnable()
    {
        _detecter.PlayerFound += OnPlayerFound;
        _detecter.PlayerLost += OnPlayerLost;
    }

    private void OnDisable()
    {
        _detecter.PlayerFound -= OnPlayerFound;
        _detecter.PlayerLost -= OnPlayerLost;
    }

    private void Die()
    {
        print("dead");
    }

    private void OnPlayerFound(Transform player)
    {
        _combat.SetTarget(player);
    }

    private void OnPlayerLost()
    {
        _combat.LoseTarget();
    }
}