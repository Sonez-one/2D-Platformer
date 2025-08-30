using UnityEngine;

public class Patroller : MonoBehaviour
{
    private readonly float _distanceToTarget = 0.2f;

    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Flipper _flipper;

    private int _nextWaypointIdex;

    public Transform NextTarget => _waypoints[_nextWaypointIdex];

    private void Start()
    {
        _nextWaypointIdex = Random.Range(0, _waypoints.Length);
    }

    public void SearchNextWaypoint()
    {
        if (IsTargetReached())
        {
            if (_nextWaypointIdex == 0)
                _nextWaypointIdex++;
            else
                _nextWaypointIdex--;
        }

        _flipper.Flip(_nextWaypointIdex == 0);
    }

    private bool IsTargetReached()
    {
        return transform.position.IsEnoughClose(_waypoints[_nextWaypointIdex].position, _distanceToTarget);
    }
}