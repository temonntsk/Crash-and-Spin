using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeEnemyMovement : EnemyMovement
{
    public override void Move(Vector3 direction) 
    {
        if (transform.position != direction)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction, Speed * Time.deltaTime);
        }
    }
}
