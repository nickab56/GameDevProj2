using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using TMPro;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Vector2 direction;
    public Transform target;
    public GameObject player;

    public GameObject doorOpen;

    private float angle;
    private float speed = 5f;

    public Transform center;
    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    public float radius;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;

    public GameObject Player;
    public PlayerInventory PlayerInventory;

    public AudioSource[] audios;

    TorchAnimation script; //creates that script data type

    // Start is called before the first frame update
    void Start()
    {
        transform.position = (transform.position - center.position).normalized * radius + center.position;
        transform.position.Set(transform.position.x, transform.position.y - .25f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 playerToCursor = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        Vector3 dir = playerToCursor.normalized;

        Vector3 cursorVector = dir * radius;

        transform.position = player.transform.position + cursorVector;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.tag == "KeyPickUp")
        {
            this.transform.localScale = new Vector3(0.12f,0.12f,0);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlayerInventory = Player.GetComponent<PlayerInventory>();
                PlayerInventory.Key = true;
                Destroy(gameObject);
                
            }
        }
        if (gameObject.tag == "TorchPickUp")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlayerInventory = Player.GetComponent<PlayerInventory>();
                PlayerInventory.Torch = true;
                Destroy(gameObject);
            }
        }

        if (gameObject.tag == "Scroll")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlayerInventory = Player.GetComponent<PlayerInventory>();
                PlayerInventory.Scroll = true;
                //Destroy(gameObject);
            }
        }

        if (gameObject.tag == "SkullTorch")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                script = gameObject.GetComponent<TorchAnimation>();

                script.enabled = true;

                gameObject.GetComponentInChildren<Light>().enabled = true;

            }
        }

        if (gameObject.tag == "HeartTorch")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                script = gameObject.GetComponent<TorchAnimation>();

                script.enabled = true;

                gameObject.GetComponentInChildren<Light>().enabled = true;

            }
        }

        if (gameObject.tag == "SwordTorch")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                script = gameObject.GetComponent<TorchAnimation>();

                script.enabled = true;

                gameObject.GetComponentInChildren<Light>().enabled = true;

            }
        }

        if (gameObject.tag == "Door")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlayerInventory = Player.GetComponent<PlayerInventory>();
                if (PlayerInventory.Key == true)
                {
                    doorOpen = Instantiate(doorOpen);
                    doorOpen.transform.position = gameObject.transform.position;
                    Destroy(gameObject);
                }
                
            }
        }


        if (gameObject.tag == "MainTorch")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                script = gameObject.GetComponent<TorchAnimation>();

                script.enabled = true;

                gameObject.GetComponentInChildren<Light>().enabled = true;

                gameObject.GetComponent<SpriteRenderer>().enabled = true;

                audios = gameObject.GetComponents<AudioSource>();

                audios[0].Play();

                audios[1].Play();

            }
        }

        if (gameObject.tag == "Treasure")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
            }
        }
        
        if (gameObject.tag != "KeyPickUp")
        {
            this.transform.localScale = new Vector3(0.1f, 0.1f, 0);
        }
    }

}
