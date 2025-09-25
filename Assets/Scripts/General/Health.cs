using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<float> ValueChanged;
    public event Action Died;

    public float MaxValue { get; private set; } = 100f;
    public float Value { get; private set; }

    private void Start()
    {
        Value = MaxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            Value -= damage;

            ValueChanged?.Invoke(Value);

            if (Value <= 0)
            {
                Died?.Invoke();
            }
        }
    }

    public void RestoreValue(float restoringValue)
    {
        if (restoringValue >= 0)
        {
            Value = Math.Clamp(Value + restoringValue, 0, MaxValue);
            ValueChanged?.Invoke(Value);
        }
    }
}