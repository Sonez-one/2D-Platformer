using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private InputReciever _inputReciever;
    [SerializeField] private Mover _mover;
    [SerializeField] private SpriteRenderer _characterSprite;
    [SerializeField] private AnimationController _animationController;

    private void FixedUpdate()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        if (_inputReciever.Direction != 0)
        {
            _mover.Move(_inputReciever.Direction);

            _characterSprite.flipX = _inputReciever.Direction < 0;

            _animationController.IsMoving = true;
        }
        else
        {
            _animationController.IsMoving = false;
        }
    }

    private void Jump()
    {
        if (_inputReciever.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
        }

        if (_groundDetector.IsGround == false)
        {
            _animationController.IsJumping = true;
        }
        else
        {
            _animationController.IsJumping = false;
        }
    }
}