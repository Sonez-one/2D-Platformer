using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Flipper _flipper;

    private int _nextWaypointIdex;

    private readonly float _offset = 0.2f;

    public Transform NextTarget => _waypoints[_nextWaypointIdex];

    private void Start()
    {
        _nextWaypointIdex = Random.Range(0, _waypoints.Length);
    }

    public void SearchNextWaypoint()
    {
        if (Vector2.Distance(transform.position, _waypoints[_nextWaypointIdex].position) < _offset)
        {
            if (_nextWaypointIdex == 0)
                _nextWaypointIdex++;
            else
                _nextWaypointIdex--;
        }

        _flipper.Flip(_nextWaypointIdex == 0);
    }
}