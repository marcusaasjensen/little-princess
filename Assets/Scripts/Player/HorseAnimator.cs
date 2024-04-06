using UnityEngine;

public class HorseAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator princessAnimator;
    private static readonly int Movement = Animator.StringToHash("Movement");
    private static readonly int IsRiding = Animator.StringToHash("isRiding");

    private void Start()
    {
        if (princessAnimator) princessAnimator.SetBool(IsRiding, true);
    }

    public void AnimatePlayerHorse(Vector2 inputDirection)
    {
        if(princessAnimator) 
            princessAnimator.SetBool(IsRiding, true);
        animator.SetFloat(Movement, inputDirection.y);
    }
}
