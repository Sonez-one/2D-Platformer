using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthSlider : MonoBehaviour
{
    private readonly float _barSpeed = 0.5f;

    [SerializeField] private Health _health;

    private Slider _bar;
    private Coroutine _coroutine;
    private float _currentValue;

    private void Awake()
    {
        _bar = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.ValueChanged += UpdateHealthValue;
        _health.Died += Died;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= UpdateHealthValue;
        _health.Died -= Died;
    }

    private void UpdateHealthValue(float currentValue)
    {
        _currentValue = currentValue;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothlySetValue());
    }

    private void Died()
    {
        OnDisable();
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