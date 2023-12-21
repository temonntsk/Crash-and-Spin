using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyMovement : EnemyMovement
{
    public override void Move(Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, Speed * Time.deltaTime);
    }
}