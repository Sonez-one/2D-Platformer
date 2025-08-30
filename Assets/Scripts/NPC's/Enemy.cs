using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private readonly float _attackDelay = 1f;
    private readonly float _movementSpeed = 2f;

    [SerializeField] private Patroller _patroller;
    [SerializeField] private EnemyDetector _enemyDetector;
    [SerializeField] private Health _health;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private EnemyAnimator _enemyAnimator;

    private float _target;
    private bool _isAttack;

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
        Move();
        СhaseTarget();
        _enemyAnimator.SetupAttack(_isAttack);
    }

    private void СhaseTarget()
    {
        if (_enemyDetector.IsEnemyInRadius && _enemyDetector.Player != null)
        {
            _flipper.Flip(_target < transform.position.x);
            _target = _enemyDetector.Player.transform.position.x;
            _isAttack = true;
        }
        else
        {
            _isAttack = false;
            _target = _patroller.NextTarget.position.x;
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(_target, transform.position.y), _movementSpeed * Time.deltaTime);
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