using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public Vector2 direction;
    public float halfHeight = 64; //this depends on our texture size
    public float halfWidth = 64; // this depends on your texture size
    public GameObject Player;


    private float localSpeed = 0;
    public bool walkInCoolDown = false;

    public AudioSource walk;

    // Get direction the player is facing (left by default)
    public bool isFacingLeft = false;

    private PlayerAnimation playerAnimation;

    public ParticleSystem WalkPS;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = this.GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }   

    private void move()
    {
        direction = Vector2.zero;

        Vector2 currentPosition = Camera.main.WorldToScreenPoint(this.transform.position);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction.y = 1;
            localSpeed += speed;
            WalkEffect();
            if (!walk.isPlaying)
            {
                walk.PlayOneShot(walk.clip, .25f);
            }
        }


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
            localSpeed += speed;
            //WalkEffect();
            //WalkTrail();
            if (isFacingLeft)
            {
                Player.transform.localScale = new Vector3(-Player.transform.localScale.x, Player.transform.localScale.y, Player.transform.localScale.z);
                isFacingLeft = false;
            }
            WalkEffect();
            if (!walk.isPlaying)
            {
                walk.PlayOneShot(walk.clip, .25f);
            }
        }



        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
            localSpeed += speed;
            //WalkEffect();
            //WalkTrail();
            WalkEffect();
            if (!walk.isPlaying)
            {
                walk.PlayOneShot(walk.clip, .25f);
            }
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
            localSpeed += speed;
            //WalkEffect();
            // WalkTrail();
            if (!isFacingLeft)
            {
                Player.transform.localScale = new Vector3(-Player.transform.localScale.x, Player.transform.localScale.y, Player.transform.localScale.z);
                isFacingLeft = true;
            }
            WalkEffect();
            if (!walk.isPlaying)
            {
                walk.PlayOneShot(walk.clip, .25f);
            }
        }

        if (direction != Vector2.zero)
        {
            direction.Normalize();
            if (!playerAnimation.isActiveAndEnabled)
            {
                playerAnimation.enabled = true;
            }
        }
        else
        {
            playerAnimation.enabled = false;
        }

        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)))
        {
            localSpeed *= .75f;
        }

        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)))
        {
            localSpeed *= .75f;
        }

        if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)))
        {
            localSpeed *= .75f;
        }

        if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)))
        {
            localSpeed *= .75f;
        }

        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)))
        {
            localSpeed *= .75f;
        }

        if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)))
        {
            localSpeed *= .75f;
        }


        Mathf.Clamp(localSpeed, 0, 4);
        localSpeed = Mathf.Lerp(localSpeed, 0, 0.4f);
        Vector3 newPositiion = new Vector3(localSpeed * direction.x * Time.deltaTime, localSpeed * direction.y * Time.deltaTime, 0); // could also use constructor and set each
        this.transform.position += newPositiion;

    }

    void WalkEffect()
    {
        if (!walkInCoolDown)
        {
            walkInCoolDown = true;
            WalkPS.Play();
            StartCoroutine(WalkCoolDown());
        }

    }

    IEnumerator WalkCoolDown()
    {
        yield return new WaitForSeconds(0.75f);
        walkInCoolDown = false;

    }
}
