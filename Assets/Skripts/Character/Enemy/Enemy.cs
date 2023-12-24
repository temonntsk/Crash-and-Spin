using UnityEngine;

[RequireComponent(typeof(BodyEnemy))]
public class Enemy : MonoBehaviour
{
    private BodyEnemy _bodyEnemy;

    protected void Awake()
    {
        _bodyEnemy = GetComponent<BodyEnemy>();
    }
}