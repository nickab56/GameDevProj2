using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWaypoint = 0;

    public Vector2 dir;
    GameObject currentWaypointTarget;

    private AI enemyAi;

    void Start()
    {
        enemyAi = GetComponent<AI>();
        dir = Vector2.zero;
        currentWaypointTarget = waypoints[0];
    }

    public Vector2 evaluateWaypoint()
    {
        float dirX = 0;
        //float dirX = Random.Range(0, 1.1f);
        //int w = Random.Range(0, 1);
        //if (w == 0)
        //    dirX *= -1;

        dir = waypoints[currentWaypoint].transform.position - this.transform.position;
        dir.x += dirX;
        dir.y += dirX;
        Debug.Log("Enemy Direction: " + dir.x + ", " + dir.y);
        if (dir.magnitude < 0.01) //enemy has reached the waypoint
        {
            currentWaypoint++;
            currentWaypoint %= waypoints.Length;
        }
        dir.Normalize();
        return dir;
    }

    private void findClosest()
    {
        float shortestDistance = float.MaxValue;
        Vector3 shortestDirection = Vector2.zero;
        Vector3 dirTemp = Vector2.zero;
        for (int i = 0; i < waypoints.Length; i++)
        {
            dirTemp = waypoints[i].transform.position - this.transform.position;
            dirTemp.z = 0;
            float distance = dirTemp.magnitude;
            if (distance < shortestDistance)
            {
                dirTemp.z = 0;
                shortestDirection = dirTemp;
                shortestDistance = distance;
                currentWaypointTarget = waypoints[i];
                currentWaypoint = (i > 0) ? i : waypoints.Length-1;
            }
        }
        dir = shortestDirection;
    }
    public Vector2 findClosestWaypoint()
    {
        Vector2 foo = this.transform.position - currentWaypointTarget.transform.position;
        float distanceToTarget = foo.magnitude;

        findClosest();

        return dir.normalized;
    }
    // Update is called once per frame
    void Update()
    {

    }
}