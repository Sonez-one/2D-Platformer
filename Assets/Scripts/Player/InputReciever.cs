using Unity.VisualScripting;
using UnityEngine;

public class InputReciever : MonoBehaviour
{
    public const string Horizontal = nameof(Horizontal);

    private bool _isJump;

    public float Direction { get; private set; }

    public void Input()
    {
        Direction = UnityEngine.Input.GetAxis(Horizontal);

        if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            _isJump = true;
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}