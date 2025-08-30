using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetupAttack(bool isAttack)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsAttack, isAttack);
    }
}