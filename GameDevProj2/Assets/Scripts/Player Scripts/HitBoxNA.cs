using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxNA : MonoBehaviour
{
    public Transform CrossHair;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CrossHair.position;
    }
}
