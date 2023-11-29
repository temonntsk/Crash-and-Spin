using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour,IDemageble
{
    [SerializeField] private BrokenWall _brokenWall;

    public void Break()
    {
        Instantiate(_brokenWall, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}
