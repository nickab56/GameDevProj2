using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScriptNA : MonoBehaviour
{
    public bool hitting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hitting = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.tag == "Enemy" && hitting == true)
        {
            Destroy(gameObject);
        }
    }

}
