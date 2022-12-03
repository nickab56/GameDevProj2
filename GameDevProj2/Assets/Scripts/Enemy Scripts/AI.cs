using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public enum AIType { waypoints, attack, none };
    public AIType aiType = AIType.none;
    public float viewAngle = 5.0f;
    public float speed = 5;

    private WayPoints waypoints;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        Vector3 dir = player.transform.position - this.transform.position;
        Vector2 returnDir = Vector2.zero;
        // Function that checks if player is within enemy sites
        if (IsPlayerInView())
        {
            aiType = AIType.attack;
        } 
        switch (aiType)
        {
            case AIType.none:
                break;
            case AIType.waypoints:
                returnDir = waypoints.evaluateWaypoint();
                break;
            case AIType.attack:
                returnDir = VectorTrack(dir);
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
    private Vector2 VectorTrack(Vector3 rawDirection)
    {
        Vector2 temp = new Vector2(rawDirection.x, rawDirection.y);
        temp.Normalize();
        return temp;
    }

    private bool IsPlayerInView()
    {
        Debug.Log("Player: " + player.transform.forward);
        Debug.Log("Enemy: " + this.transform.forward);
        Vector3 targetDir = player.transform.position - this.transform.position;
        Vector3 up = this.transform.up;
        float angle = Vector3.Angle(targetDir, up);
        Debug.Log("Angle: " + angle);
        if (angle < viewAngle)
        {
            Debug.Log("YOU ARE WITHIN VIEW");
            return true;
        }
        //var dist = Vector3.Distance(target.position, enemy.position);
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
        }
    }
}

