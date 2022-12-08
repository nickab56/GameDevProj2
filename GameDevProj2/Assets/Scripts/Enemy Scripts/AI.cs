using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public enum AIType { waypoints, attack, none };
    public AIType aiType = AIType.none;
    public float viewAngle = 5.0f;
    public float speed = 3;

    private WayPoints waypoints;
    private EnemyAnimation enemyAnimation;
    private GameObject player;

    // Knockback implementation
    private Vector2 dir;
    public float KBCurrent = 0;
    public float KBTotal = 0.2f;
    public float KBForce = 1.5f;

    // Stun implementation
    public float StunCurrent = 0;
    public float StunTotal = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        waypoints = this.GetComponent<WayPoints>();
        enemyAnimation = this.GetComponent<EnemyAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = Vector2.zero;
        if (KBCurrent <= 0 && StunCurrent <= 0) {
            // Normal movement 
            if (player != null)
            {
                temp = speed * Time.deltaTime * ProcessAI();
            }
        } 
        else
        {
            Debug.Log(dir);
            // Still getting knocked back
            temp = KBForce * speed * Time.deltaTime * dir;
            KBCurrent -= Time.deltaTime;
            StunCurrent -= Time.deltaTime;
        }

        transform.position += new Vector3(temp.x, temp.y, 0);
    }

    Vector2 ProcessAI()
    {
        Vector3 dir = player.transform.position - this.transform.position;

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
        };
        if (gameObject.tag == "Weapon")
        {
            // Knockback
            dir = (this.transform.position - gameObject.transform.position).normalized;
            KBForce = 1.5f;
            KBCurrent = KBTotal;
            StunCurrent = StunTotal + KBCurrent;
            StartCoroutine(FreezeAnimation());

            // Provoked Enemy, begin attack
            aiType = AIType.attack;
        }
        if (gameObject.tag == "Boundary")
        {
            Debug.Log("HIT BOUNDARY");
            KBForce = 0.65f;
            dir *= -1;
        }
    }

    public IEnumerator FreezeAnimation()
    {
        enemyAnimation.enabled = false;
        yield return new WaitForSeconds(KBCurrent);
        enemyAnimation.enabled = true;
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverDeathScene");
    }
}

