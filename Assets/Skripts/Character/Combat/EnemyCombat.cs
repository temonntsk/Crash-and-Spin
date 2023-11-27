using UnityEngine;

public abstract class EnemyCombat : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    protected Transform _target;
  
    public virtual void Attack(Transform target)
    {
        _target = target;
       _weapon.Attack();
    }
}