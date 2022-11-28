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


    // Start is called before the first frame update
    void Start()
    {
        
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
            //WalkEffect();
            //WalkTrail();
        }


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
            localSpeed += speed;
            //WalkEffect();
            //WalkTrail();
        }



        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
            localSpeed += speed;
            //WalkEffect();
            //WalkTrail();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
            localSpeed += speed;
            //WalkEffect();
            // WalkTrail();
        }

        if (direction != Vector2.zero)
        {
            direction.Normalize();
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
}
