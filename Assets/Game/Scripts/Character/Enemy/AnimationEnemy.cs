using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationEnemy : MonoBehaviour
{
    private readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));

    [SerializeField] private BaseCombat _combat;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_combat.ActiveAttack)
            _animator.SetBool(IsAttack, true);
        else
            _animator.SetBool(IsAttack, false);
    }
}
