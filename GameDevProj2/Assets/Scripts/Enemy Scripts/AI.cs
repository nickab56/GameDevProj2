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
        //Vector2 returnDir = Vector2.zero;
        // Function that checks if player is within enemy sites
        Vector2 returnDir = CheckPlayerView();
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

    private Vector2 CheckPlayerView()
    {
        Vector3 targetDir = player.transform.position - this.transform.position;
        Vector3 up = this.transform.up;

        float angle = Vector3.Angle(targetDir, up);
        float dist = Vector3.Distance(this.transform.position, player.transform.position);

        //Debug.Log("Angle: " + angle);
        if (angle < viewAngle)
        {
            aiType = AIType.attack;
        }
        
        if (aiType == AIType.attack && dist > 5.0f)
        {
            aiType = AIType.waypoints;
            return waypoints.findClosestWaypoint();
        }
        return Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Player")
        {
            Destroy(gameObject);
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
}

