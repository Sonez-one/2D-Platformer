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

    private bool IsMoving => _inputReciever.Direction != 0;
    private bool IsJumping => !_surafaceDetector.IsJumpable;
    private bool IsAttacking => _inputReciever.IsAttack;
    private bool IsFacingLeft => _inputReciever.Direction < 0;

    private void Update()
    {
        _inputReciever.Input();
        _flipper.Flip(IsFacingLeft);
        _playerAnimator.SetupRun(IsMoving);
        _playerAnimator.SetupJump(IsJumping);
        _playerAnimator.SetupAttack(IsAttacking);
    }

    private void FixedUpdate()
    {
        Run();
        Jump();
    }

    private void OnEnable()
    {
        _inputReciever.AttackButtonPressed += Attack;
        _itemPeaker.HealthRestoring += RestoreHealth;
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _inputReciever.AttackButtonPressed -= Attack;
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
        _attacker.Attack();
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