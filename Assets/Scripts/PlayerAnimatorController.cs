using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    private static readonly int MovementSpeed = Animator.StringToHash("movementSpeed");

    private void Awake()
    {
        // "Player" 오브젝트 기준으로 자식 오브젝트인 "arms_assault_riffle_01" 오브젝트에 Animator 컴포넌트가 있다.
        animator = GetComponentInChildren<Animator>();
    }

    public float MoveSpeed
    {
        set => animator.SetFloat(MovementSpeed, value);
        get => animator.GetFloat(MovementSpeed);
    }

    public void Play(string stateName, int layer, float normalizedTime)
    {
        animator.Play(stateName, layer, normalizedTime);
    }
}
