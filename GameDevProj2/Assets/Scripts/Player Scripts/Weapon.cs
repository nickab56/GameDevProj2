using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
