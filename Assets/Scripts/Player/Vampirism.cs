using System;
using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Attacker))]
public class Vampirism : MonoBehaviour
{
    private readonly float _cooldownTime = 4f;
    private readonly float _activeTime = 6f;
    private readonly float _damageDelay = 1.5f;
    private readonly float _damage = 20f;
    private readonly int _colliderCount = 1;

    [SerializeField] private CircleCollider2D _radiusCollider;
    [SerializeField] private LayerMask _layerMask;

    private Health _health;
    private Attacker _attacker;
    private Collider2D[] _colliders;
    private bool _isReady;

    public event Action<float, float> TimerChanged;
    public event Action CastStarted;
    public event Action CastCompleted;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _attacker = GetComponent<Attacker>();
    }

    private void Start()
    {
        _isReady = true;
        _colliders = new Collider2D[_colliderCount];
    }

    public void Use()
    {
        if (_isReady)
            StartCoroutine(CastAbility());
    }

    private IEnumerator CastAbility()
    {
        CastStarted?.Invoke();

        _isReady = false;

        Coroutine causeDamage = StartCoroutine(CauseDamage());

        var wait = new WaitForEndOfFrame();
        float timer = _activeTime;

        while (timer > 0)
        {
            yield return wait;

            timer = Mathf.Clamp(timer - Time.deltaTime, 0, _activeTime);

            TimerChanged?.Invoke(timer, _activeTime);
        }

        StopCoroutine(causeDamage);
        StartCoroutine(WaitCooldown());
    }

    private IEnumerator WaitCooldown()
    {
        CastCompleted?.Invoke();

        var wait = new WaitForEndOfFrame();
        float timer = 0;

        while (timer < _cooldownTime)
        {
            yield return wait;

            timer = Mathf.Clamp(timer + Time.deltaTime, 0, _cooldownTime);

            TimerChanged?.Invoke(timer, _cooldownTime);
        }

        _isReady = true;
    }

    private IEnumerator CauseDamage()
    {
        var wait = new WaitForSeconds(_damageDelay);

        while (enabled)
        {
            int foundCollider = Physics2D.OverlapCircleNonAlloc(transform.position, _radiusCollider.radius, _colliders, _layerMask);
            Enemy closestEnemy = FindClosestEnemy(_colliders.Take(foundCollider).ToArray());

            if (closestEnemy != null && _health.Value != _health.MaxValue)
            {
                _health.RestoreValue(_damage);
                _attacker.Attack(_damage);
            }

            yield return wait;
        }
    }

    private Enemy FindClosestEnemy(Collider2D[] colliders)
    {
        float minDistance = float.MaxValue;
        Enemy closestEnemy = null;

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out Enemy enemy) && transform.position.SqrDistance(enemy.transform.position) < minDistance)
            {
                minDistance = Mathf.Sqrt(transform.position.SqrDistance(enemy.transform.position));
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}