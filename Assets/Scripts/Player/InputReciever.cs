using UnityEngine;

public class InputReciever : MonoBehaviour
{
    public const string Horizontal = nameof(Horizontal);

    private bool _isJump;
    private bool _isAttack;

    public float Direction { get; private set; }

    public void Input()
    {
        Direction = UnityEngine.Input.GetAxis(Horizontal);

        if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            _isJump = true;

        if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            _isAttack = true;
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);
    public bool GetIsAttack() => GetBoolAsTrigger(ref _isAttack);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}