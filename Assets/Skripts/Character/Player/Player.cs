using Movement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCombat _combat;
    [SerializeField] private PlayerMovement _movement;


    private void FixedUpdate()
    {
        if(_movement.IsMoved)
        {
            _combat.Attack();
        }
    }
}
