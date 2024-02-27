using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int IsGrounded = Animator.StringToHash("isGrounded");

    public void AnimatePlayerWalk(Vector2 inputDirection)
    {
        var isWalking = inputDirection != Vector2.zero;
        animator.SetBool(IsWalking, isWalking);
    }
    
    public void AnimatePlayerJump(bool isGrounded)
    {
        animator.SetBool(IsGrounded, isGrounded);
    }
}
