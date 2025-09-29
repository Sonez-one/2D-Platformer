using System;
using UnityEngine;

public class InputReciever : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const KeyCode Jump = KeyCode.W;
    private const KeyCode Attack = KeyCode.E;
    private const KeyCode Vampirism = KeyCode.Q;

    private bool _isJump;

    public event Action AttackButtonPressed;
    public event Action VampirismButtonPressed;

    public float Direction { get; private set; }
    public bool IsAttack { get; private set; }

    public void ReadInput()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(Jump))
            _isJump = true;

        if (Input.GetKeyDown(Attack))
        {
            IsAttack = true;

            AttackButtonPressed?.Invoke();
        }
        else
        {
            IsAttack = false;
        }

        if (Input.GetKeyDown(Vampirism))
            VampirismButtonPressed?.Invoke();
    }

    public bool GetIsJump() =>
        GetBoolAsTrigger(ref _isJump);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}