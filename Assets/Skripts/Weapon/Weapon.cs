using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
   [SerializeField] private float _damage;

    public abstract void Attack();

}
