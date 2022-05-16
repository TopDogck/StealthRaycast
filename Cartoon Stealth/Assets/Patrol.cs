using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed = 2;
    public float range = 1f;

    private int waypointIndex;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (distance < range)
        {
            Index();
        }
        Patroller();
    }

    public void Patroller()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void Index()
    {
        waypointIndex++;

        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
}
