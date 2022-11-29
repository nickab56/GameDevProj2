using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public enum AIType { vector, delta, evade, pattern, waypoints, none };
    public AIType aiType = AIType.none;
    public float speed = 5;

    private GameObject player;
    private AIPatterns patterns;
    //private WayPoints waypoints;

    // Start is called before the first frame update
    void Start()
    {
        //waypoints = this.GetComponent<WayPoints>();
        patterns = this.GetComponent<AIPatterns>();
        name = "AIEnemy_" + Time.time.ToString();
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("AI::Start couldn't find player for " + name.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = speed * ProcessAI() * Time.deltaTime;
        transform.position += new Vector3(temp.x, temp.y, 0);
    }

    Vector2 ProcessAI()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Vector2 returnDir = Vector2.zero;
        switch (aiType)
        {
            case AIType.none:
                break;
            case AIType.vector:
                returnDir = VectorTrack(dir);
                break;
            case AIType.delta:
                returnDir = deltaTrack(dir);
                break;
            case AIType.evade:
                returnDir = evade(dir);
                break;
            case AIType.pattern:
                returnDir = patterns.evaluatePattern();
                break;
            case AIType.waypoints:
                //returnDir = wayPoints.evaluateWayPoints();
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

    private Vector2 deltaTrack(Vector3 rawDirection)
    {
        // Consider: If deltaX is less than deltaY, change tempDir.y
        Vector2 tempDir = Vector2.zero;
        float deltaX = player.transform.position.x - transform.position.x;
        float deltaY = player.transform.position.y - transform.position.y;
        if (deltaX > 0.1)
        {
            tempDir.x = 1;
        }
        else if (deltaX < -0.1)
        {
            tempDir.x = -1;
        }
        else if (deltaY > 0.1)
        {
            tempDir.y = 1;
        }
        else if (deltaY < -0.1)
        {
            tempDir.y = -1;
  
        }
        float distance = rawDirection.magnitude;
        if (distance < 1)
        {
            speed /= 2;
        } else
        {
            speed = 5;
        }
        return tempDir;

    }

    private Vector2 evade(Vector2 rawDirection)
    {
        Vector2 tempDir = Vector2.zero;
        float distance = rawDirection.magnitude;
        tempDir = -1 * VectorTrack(rawDirection);
        if (distance < 2)
        {
            tempDir = -1 * VectorTrack(rawDirection);
            return tempDir;
        }
        return tempDir;
    }

    private Vector2 VectorTrack(Vector3 rawDirection)
    {
        Vector2 temp = new Vector2(rawDirection.x, rawDirection.y);
        temp.Normalize();
        return temp;
    }

}

