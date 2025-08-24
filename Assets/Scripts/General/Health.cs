using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _value;

    public event Action HealthValueChanged;
    public event Action Died;

    private readonly float _maxValue = 100f;

    private void Start()
    {
        _value = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            _value -= damage;

            HealthValueChanged?.Invoke();

            if (_value <= 0)
            {
                Died?.Invoke();
            }
        }
    }

    public void RestoreValue(float restoringValue)
    {
        if (restoringValue >= 0)
        {
            _value = Math.Clamp(_value + restoringValue, 0, _maxValue);
            HealthValueChanged?.Invoke();
        }
    }
}