using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSwing : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 0.1f;
    
    private bool reach = false;
    new private Renderer renderer;
    private bool isInvisible;

    public bool isFacingLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(retreat());
        //direction = new Vector2(1, 0);
        Destroy(this.gameObject, .65f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 newPosition;
        direction = (isFacingLeft) ? direction = new(-transform.up.x, -transform.up.y) : direction = new(transform.up.x, transform.up.y);
        if (reach == false)
        {
            newPosition = new Vector3(speed * direction.x * Time.deltaTime, speed * direction.y * Time.deltaTime, 0);
            Debug.Log(newPosition);
            this.transform.position += newPosition;
        }

        if (reach == true)
        {
            newPosition = new Vector3(-(speed * direction.x) * Time.deltaTime, -(speed * direction.y) * Time.deltaTime, 0);
            this.transform.position += newPosition;
        }
    }

    IEnumerator retreat()
    {
        reach = true;
        yield return new WaitForSeconds(.3f);
        reach = false;
        yield return new WaitForSeconds(.3f);
        retreat();
    }
}
