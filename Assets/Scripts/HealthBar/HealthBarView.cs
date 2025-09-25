using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBarView : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected Slider _bar;

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

    protected abstract void UpdateHealthValue(float currentValue);

    private void Died()
    {
        OnDisable();
    }
}