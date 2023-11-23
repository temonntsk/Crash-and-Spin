using UnityEngine;

public class Enemy : MonoBehaviour
{
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

    private void OnPlayerFound(Player player)
    {
        _target = player.transform;
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
