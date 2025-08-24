using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private float _speed;

    private int _nextWaypointIdex;

    private readonly float _offset = 0.2f;

    private void Start()
    {
        _nextWaypointIdex = Random.Range(0, _waypoints.Length);
    }

    private void Update()
    {
        Move();
        _flipper.Flip(_nextWaypointIdex == 0);
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_nextWaypointIdex].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _waypoints[_nextWaypointIdex].position) < _offset)
        {
            if (_nextWaypointIdex == 0)
                _nextWaypointIdex++;
            else
                _nextWaypointIdex--;
        }
    }
}