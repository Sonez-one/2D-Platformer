using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private InputReciever _inputReciever;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private bool IsMoving => _inputReciever.Direction != 0;
    private bool IsJumping => !_groundDetector.IsGround;
    private bool IsFacingLeft => _inputReciever.Direction < 0;

    private void Update()
    {
        _inputReciever.Input();
        _flipper.Flip(IsFacingLeft);
        _playerAnimator.SetupRun(IsMoving);
        _playerAnimator.SetupJump(IsJumping);
    }

    private void FixedUpdate()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        if (IsMoving)
        {
            _mover.Move(_inputReciever.Direction);
        }
    }

    private void Jump()
    {
        if (_inputReciever.GetIsJump() && _groundDetector.IsGround)
        {
            _jumper.Jump();
        }
    }
}