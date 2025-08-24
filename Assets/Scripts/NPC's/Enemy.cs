using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patroller _patroller;
    [SerializeField] private EnemyDetector _enemyDetector;
    [SerializeField] private Health _health;
    [SerializeField] private Flipper _flipper;

    private float _target;

    private readonly float _speed = 2f;

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    private void Update()
    {
        _patroller.SearchNextWaypoint();
        Move();
        DetectTarget();
    }

    private void DetectTarget()
    {
        if (_enemyDetector.IsEnemyInRadius && _enemyDetector.Player != null)
        {
            _flipper.Flip(_target < transform.position.x);
            _target = _enemyDetector.Player.transform.position.x;
        }
        else
        {
            _target = _patroller.NextTarget.position.x;
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(_target, transform.position.y), _speed * Time.deltaTime);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}