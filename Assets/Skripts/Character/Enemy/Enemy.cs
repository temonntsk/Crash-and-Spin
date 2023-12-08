using UnityEngine;

[RequireComponent(typeof(PlayerDetecter))]
[RequireComponent(typeof(BodyEnemy))]
public class Enemy : MonoBehaviour
{
    private PlayerDetecter _detecter;
    private BodyEnemy _bodyEnemy;

    protected void Awake()
    {
        _bodyEnemy = GetComponent<BodyEnemy>();
        _detecter = GetComponentInChildren<PlayerDetecter>();
    }

    private void Die()
    {
        print("dead");
    }
}