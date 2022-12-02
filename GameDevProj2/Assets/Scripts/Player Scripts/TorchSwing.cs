using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSwing : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 0.1f;

    private Renderer renderer;
    private bool isInvisible;
    // Start is called before the first frame update
    void Start()
    {
        //direction = new Vector2(1, 0);
        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 newPosition = new Vector3(speed * transform.up.x * Time.deltaTime, speed * transform.up.y * Time.deltaTime, 0);
        this.transform.position += newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Do stuff to something
        GameObject gameObject = collision.gameObject;
        if ((gameObject.tag == "Astroid") || (gameObject.tag == "Astroid2") || (gameObject.tag == "UFO"))
        {
            //End the Game and lock player movement
            Destroy(gameObject);
            Destroy(this.gameObject);
        }
    }
}
