using UnityEngine;

public class BaseCombat : MonoBehaviour
{
    [SerializeField] private float _focusDelay;

    protected Focalization Focalization;
    protected Transform Target;
    private PlayerDetecter _detecter;
    private ExclamationMarkEnemy _exclamationMarkEnemy;

    public bool ActiveAttack { get; protected set; }

    protected virtual void Awake()
    {
        _exclamationMarkEnemy = GetComponentInChildren<ExclamationMarkEnemy>();
        _exclamationMarkEnemy.Initialization(_focusDelay);
        Focalization = new Focalization(_focusDelay, transform);
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

    private void OnPlayerFound(Transform player)
    {
        Target = player;
        Focalization.SetTarget(Target);
        _exclamationMarkEnemy.ToFill();
    }

    private void OnPlayerLost()
    {
        Target = null;
        Focalization.LoseTarget();
        _exclamationMarkEnemy.ToEmpty();
    }
}

