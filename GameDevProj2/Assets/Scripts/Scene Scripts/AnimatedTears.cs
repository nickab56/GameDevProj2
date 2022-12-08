using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTears : MonoBehaviour
{

    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(0, speed * -1 * Time.deltaTime, 0);
        this.transform.position += newPosition;
    }
}
