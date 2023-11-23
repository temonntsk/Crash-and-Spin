using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    [SerializeField] private BrokenWall _brokenWall;

    public void Break()
    {
        Instantiate(_brokenWall, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
