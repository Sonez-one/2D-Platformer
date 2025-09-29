using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class VampirismRadiusViewer : MonoBehaviour
{
    [SerializeField] Vampirism _ability;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _ability.CastStarted += Show;
        _ability.CastCompleted += Hide;
    }

    private void OnDisable()
    {
        _ability.CastStarted -= Show;
        _ability.CastCompleted -= Hide;
    }

    private void Show()
    {
        _renderer.enabled = true;
    }

    private void Hide()
    {
        _renderer.enabled = false;
    }
}