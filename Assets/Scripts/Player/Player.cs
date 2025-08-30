using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private JumpSurfaceDetector _surafaceDetector;
    [SerializeField] private InputReciever _inputReciever;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private ItemPeaker _itemPeaker;
    [SerializeField] private Health _health;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private bool IsAttack;

    private bool IsMoving => _inputReciever.Direction != 0;
    private bool IsJumping => !_surafaceDetector.IsJumpable;
    private bool IsFacingLeft => _inputReciever.Direction < 0;

    private void Update()
    {
        _inputReciever.Input();
        _flipper.Flip(IsFacingLeft);
        _playerAnimator.SetupRun(IsMoving);
        _playerAnimator.SetupJump(IsJumping);
        _playerAnimator.SetupAttack(IsAttack);
    }

    private void FixedUpdate()
    {
        Run();
        Jump();
        Attack();
    }

    private void OnEnable()
    {
        _itemPeaker.HealthRestoring += RestoreHealth;
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _itemPeaker.HealthRestoring -= RestoreHealth;
        _health.Died -= Die;
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
        if (_inputReciever.GetIsJump() && _surafaceDetector.IsJumpable)
        {
            _jumper.Jump();
        }
    }

    private void Attack()
    {
        if (_inputReciever.GetIsAttack())
        {
            IsAttack = true;
            _attacker.Attack();
        }
        else
        {
            IsAttack = false;
        }
    }

    private void RestoreHealth(float restoringValue)
    {
        _health.RestoreValue(restoringValue);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}