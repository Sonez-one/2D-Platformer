using System.Collections;
using UnityEngine;

public class SmoothHealthSlider : HealthBarView
{
    private readonly float _barSpeed = 0.5f;

    private Coroutine _coroutine;
    private float _currentValue;

    protected override void UpdateHealthValue(float currentValue)
    {
        _currentValue = currentValue;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothlySetValue());
    }

    private IEnumerator SmoothlySetValue()
    {
        float barNextValue = _currentValue / _health.MaxValue;

        while (Mathf.Approximately(_bar.value, barNextValue) != true)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, barNextValue, _barSpeed * Time.deltaTime);

            yield return null;
        }
    }
}