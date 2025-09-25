using System;
using UnityEngine;

public class InputReciever : MonoBehaviour
{
    public const string Horizontal = nameof(Horizontal);

    private bool _isJump;

    public float Direction { get; private set; }
    public bool IsAttack { get; private set; }
   
    public event Action AttackButtonPressed;

    public void Input()
    {
        Direction = UnityEngine.Input.GetAxis(Horizontal);

        if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            _isJump = true;

        if (UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            IsAttack = true;

            AttackButtonPressed?.Invoke();
        }
        else
        {
            IsAttack = false;
        }
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}