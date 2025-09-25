using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetupAttack(bool isAttack)
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsAttack, isAttack);
    }
}