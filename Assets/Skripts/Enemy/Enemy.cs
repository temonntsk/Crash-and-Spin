using UnityEngine;

public class Enemy : MonoBehaviour
{// TODO: сделать интерефей айдемаджебле тк и стены и противники и игрок могутразжушаться
 // но у каждого своя реализация  так же объединить игрока и противника (получается что IDemageble присутвует в стенах + враг + игрок но враг и игрок по своему а значит их можно объединити и человека)
    [SerializeField] private float _focusDelay;
    [SerializeField] private EnemyCombat _combat;

    private PlayerDetecter _detecter;
    private Transform _target;
    private float _time;
    private bool _isTargetSet;

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

    private void Update()
    {
        if (_isTargetSet)
        { 
            PrepareAttack();
        }
    }

    private void Die()
    {
        print("dead");
    }

    private void OnPlayerFound(Transform player)
    {
        _target = player;
        _isTargetSet = true;
    }

    private void OnPlayerLost()
    {
        _isTargetSet = false;
        _target = null;
    }

    private void PrepareAttack()
    {
        transform.LookAt(_target);

        _time += Time.deltaTime;

        if (_time > _focusDelay)
        {
            _time = 0;
        }
    }
}
