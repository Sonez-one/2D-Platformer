using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _enemySprite;

    private int _nextWaypointIdex;

    private void Start()
    {
        _nextWaypointIdex = Random.Range(0, _waypoints.Length);
    }

    private void Update()
    {
        Move();

        _enemySprite.flipX = _nextWaypointIdex == 0;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_nextWaypointIdex].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _waypoints[_nextWaypointIdex].position) < 0.2f)
        {
            if (_nextWaypointIdex == 0)
                _nextWaypointIdex++;
            else
                _nextWaypointIdex--;
        }
    }
}
