using UnityEngine;

[RequireComponent(typeof(BodyEnemy))]
public class Enemy : MonoBehaviour
{
    private BodyEnemy _bodyEnemy;

    private void Awake()
    {
        _bodyEnemy = GetComponent<BodyEnemy>();
    }
}