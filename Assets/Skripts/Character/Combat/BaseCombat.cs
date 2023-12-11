using UnityEngine;

public class BaseCombat : MonoBehaviour
{
    [SerializeField] private float _focusDelay;

    protected Focalization Focalization;
    private PlayerDetecter _detecter;
    protected Transform Target;

    protected virtual void Awake()
    {
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
    }

    private void OnPlayerLost()
    {
        Focalization.LoseTarget();
    }
}

