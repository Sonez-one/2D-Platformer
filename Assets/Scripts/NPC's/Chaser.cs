using UnityEngine;

public class Chaser : MonoBehaviour
{
    private readonly float _movementSpeed = 2f;

    [SerializeField] private EnemyDetector _enemyDetector;
    [SerializeField] private Flipper _flipper;

    public float Target { get; private set; }
    public bool IsChasing { get; private set; }

    public void ChaseTarget(Patroller patroller)
    {
        if (_enemyDetector.IsEnemyInRadius && _enemyDetector.Player != null)
        {
            Target = _enemyDetector.Player.transform.position.x;

            _flipper.Flip(Target < transform.position.x);

            IsChasing = true;
        }
        else
        {
            IsChasing = false;
            Target = patroller.NextTarget.position.x;
        }

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Target, transform.position.y),
                                                 _movementSpeed * Time.deltaTime);
    }
}
