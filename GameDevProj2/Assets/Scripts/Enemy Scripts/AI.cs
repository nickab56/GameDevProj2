using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public enum AIType { waypoints, none };
    public AIType aiType = AIType.none;
    public float speed = 5;

    private WayPoints waypoints;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = this.GetComponent<WayPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = speed * Time.deltaTime * ProcessAI();
        transform.position += new Vector3(temp.x, temp.y, 0);
    }

    Vector2 ProcessAI()
    {
        Vector2 returnDir = Vector2.zero;
        switch (aiType)
        {
            case AIType.none:
                break;
            case AIType.waypoints:
                returnDir = waypoints.evaluateWaypoint();
                break;
            default:
                break;
        }
        if (Mathf.Abs(returnDir.x) < 0.1)
        {
            returnDir.x = 0;
        }
        if (Mathf.Abs(returnDir.y) < 0.1)
        {
            returnDir.y = 0;
        }
        return returnDir;
    }
}

