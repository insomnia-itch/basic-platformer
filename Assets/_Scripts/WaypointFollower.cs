using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed  = 2f;

    private void Update()
    {
        Vector3 currentWaypointPosition = waypoints[currentWaypointIndex]
            .transform
            .position;

        // zero would be too imprecise here, which is why a small number is better
        if (Vector2.Distance(currentWaypointPosition, transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
                currentWaypointPosition = waypoints[currentWaypointIndex]
                    .transform
                    .position;
            }
        }

        // What a neat method!
        transform.position = Vector2.MoveTowards(
            transform.position,
            currentWaypointPosition,
            Time.deltaTime * speed
        );
    }
}
