using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    private int _currentWaypoint = 0;
    private float _speed = 3;

    private void Update()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Count;

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}
