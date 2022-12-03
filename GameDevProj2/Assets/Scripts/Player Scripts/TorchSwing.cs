using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSwing : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 0.1f;
    
    private bool reach = false;
    private Renderer renderer;
    private bool isInvisible;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(retreat());
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
        Vector3 newPosition;
        if (reach == false)
        {
            newPosition = new Vector3(speed * transform.up.x * Time.deltaTime, speed * transform.up.y * Time.deltaTime, 0);
            this.transform.position += newPosition;
        }

        if (reach == true)
        {
            newPosition = new Vector3(-(speed * transform.up.x) * Time.deltaTime, -(speed * transform.up.y) * Time.deltaTime, 0);
            this.transform.position += newPosition;
        }
        
        


        
    }

    IEnumerator retreat()
    {
        reach = true;
        yield return new WaitForSeconds(1.5f);
        reach = false;
        yield return new WaitForSeconds(1.5f);
        retreat();
    }
    
}
