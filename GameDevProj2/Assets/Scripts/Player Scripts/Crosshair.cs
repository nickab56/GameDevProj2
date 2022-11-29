using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Crosshair : MonoBehaviour
{
    public Vector2 direction;
    public Transform target;
    public GameObject player;

    private float angle;
    private float speed = 5f;

    public Transform center;
    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    public float radius;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = (transform.position - center.position).normalized * radius + center.position;
        transform.position.Set(transform.position.x, transform.position.y - .25f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 playerToCursor = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;

        Vector3 dir = playerToCursor.normalized;

        Vector3 cursorVector = dir * radius;

        transform.position = player.transform.position + cursorVector;

    }

}
