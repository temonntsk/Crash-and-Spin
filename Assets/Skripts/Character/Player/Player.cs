using Movement;
using System.Collections;
using System.Collections.Generic;
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
