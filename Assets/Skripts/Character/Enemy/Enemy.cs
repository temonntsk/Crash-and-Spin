using UnityEngine;
[RequireComponent(typeof(EnemyCombat))]
[RequireComponent(typeof(PlayerDetecter))]
public class Enemy : MonoBehaviour
{// TODO: сделать интерефей айдемаджебле тк и стены и противники и игрок могутразжушаться
 // но у каждого своя реализация  так же объединить игрока и противника (получается что IDemageble присутвует в стенах + враг + игрок но враг и игрок по своему а значит их можно объединити и человека)

    private EnemyCombat _combat;
    private PlayerDetecter _detecter;


    private void Awake()
    {
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
        _combat.PrepareAttack(player);
    }

    private void OnPlayerLost()
    {
        _combat.ResetAttack();
    }
}
