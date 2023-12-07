using Movement;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{ 
    private PlayerCombat _combat;
    private PlayerMovement _movement;

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _combat = GetComponentInChildren<PlayerCombat>();
    }

    private void FixedUpdate()
    {
        if(_movement.IsMoved)
        {
            _combat.Attack();
        }
    }
}
