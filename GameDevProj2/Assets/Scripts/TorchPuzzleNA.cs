using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TorchPuzzleNA : MonoBehaviour
{
    public bool Skull = false;
    public bool Heart = false;
    public bool Sword = false;

    GameObject SkullTorch;

    private int[] Puzzle = { 1, 2, 3 };
    private int[] Answer = { };
    private int numActiveLights = 0;

    TorchAnimation script;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.tag == "SkullTorch")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                gameObject.GetComponentInChildren<Light>().enabled = true;
                
            }
        }

        if (gameObject.tag == "HeartTorch")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                gameObject.GetComponentInChildren<Light>().enabled = true;
            }
        }

        if (gameObject.tag == "SwordTorch")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (gameObject.GetComponentInChildren<Light>().isActiveAndEnabled)
                {
                    numActiveLights++;
                }

            }
        }
    }
}
