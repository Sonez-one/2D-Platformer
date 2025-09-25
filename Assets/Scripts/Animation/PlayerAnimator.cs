using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetupJump(bool isJumping)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsJumping, isJumping);
    }

    public void SetupRun(bool isMoving)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsMoving, isMoving);
    }

    public void SetupAttack(bool isAttack)
    {
        if (isAttack)
            _animator.SetTrigger(PlayerAnimatorData.Params.IsAttack);
    }
}