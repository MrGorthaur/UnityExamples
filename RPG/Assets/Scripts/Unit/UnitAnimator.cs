using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UnitAnimator : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamageAnimation() 
    { 
        _animator.SetTrigger("TakeDamage"); 
    }
    public void DieAnimation()
    {
        _animator.Play("Die");
    }




}

