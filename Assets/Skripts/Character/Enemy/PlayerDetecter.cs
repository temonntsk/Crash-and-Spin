using System;
using UnityEngine;

public class PlayerDetecter : MonoBehaviour
{
    [SerializeField] private ExclamationMarkEnemy _exclamationMarkEnemy;

    public event Action<Transform> PlayerFound;
    public event Action PlayerLost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            PlayerFound?.Invoke(player.transform);
            //_exclamationMarkEnemy.ToFill();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            PlayerLost?.Invoke();
           // _exclamationMarkEnemy.ToEmpty();
        }
    }
}
