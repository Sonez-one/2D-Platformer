using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;

    public bool IsMoving { private get; set; }
    public bool IsJumping { private get; set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _animator.SetBool("IsMoving", IsMoving);
        _animator.SetBool("IsJumping", IsJumping);
    }
}