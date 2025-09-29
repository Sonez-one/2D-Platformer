using UnityEngine;
using UnityEngine.UI;

public class VampirismTimerViewer : MonoBehaviour
{
    [SerializeField] private Vampirism _ability;

    private Slider _bar;

    private void Awake()
    {
        _bar = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _ability.TimerChanged += UpdateTimerValue;
    }

    private void OnDisable()
    {
        _ability.TimerChanged -= UpdateTimerValue;
    }

    private void UpdateTimerValue(float timer, float duration)
    {
        _bar.value = Mathf.Clamp01(timer / duration);
    }
}