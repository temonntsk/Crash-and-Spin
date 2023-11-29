using UnityEngine;

[RequireComponent(typeof(EnemyCombat))]
[RequireComponent(typeof(PlayerDetecter))]
public class Enemy : MonoBehaviour
{
    private EnemyCombat _combat;
    private PlayerDetecter _detecter;


    private void Awake()
    {
        _detecter = GetComponentInChildren<PlayerDetecter>();
        _combat = GetComponent<EnemyCombat>();
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
        _combat.PrepareAttack(player);
    }

    private void OnPlayerLost()
    {
        _combat.ResetAttack();
    }
}