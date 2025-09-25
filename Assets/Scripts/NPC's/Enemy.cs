using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private readonly float _attackDelay = 1f;

    [SerializeField] private Patroller _patroller;
    [SerializeField] private Health _health;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private EnemyAnimator _enemyAnimator;
    [SerializeField] private Chaser _chaser;

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;

        StopCoroutine(Attack());
    }

    private void Start()
    {
        StartCoroutine(Attack());
    }

    private void Update()
    {
        _patroller.SearchNextWaypoint();
        _chaser.ChaseTarget(_patroller);
        _enemyAnimator.SetupAttack(_chaser.IsChasing);
    }

    private IEnumerator Attack()
    {
        var wait = new WaitForSeconds(_attackDelay);

        while (enabled)
        {
            _attacker.Attack();

            yield return wait;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}