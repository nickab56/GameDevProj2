using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TorchPuzzleNA : MonoBehaviour
{
    public Sprite NoFlame;

    private GameObject SkullTorch;
    private GameObject HeartTorch;
    private GameObject SwordTorch;

    public int STVal = 1;
    public int HTVal = 2;
    public int SWVal = 3;

    private bool Skull = false;
    private bool Heart = false;
    private bool Sword = false;

    private int[] Puzzle = { 1, 2, 3 };
    private int[] Answer = new int[3];
    private int numActiveLights = 0;

    // Start is called before the first frame update
    void Start()
    {
        SkullTorch = GameObject.FindGameObjectWithTag("SkullTorch");
        HeartTorch = GameObject.FindGameObjectWithTag("HeartTorch");
        SwordTorch = GameObject.FindGameObjectWithTag("SwordTorch");
        // TODO - Error handling
    }

    // Update is called once per frame
    void Update()
    {
        CheckLights();
    }

    private void CheckLights()
    {
        if (SwordTorch.GetComponentInChildren<Light>().isActiveAndEnabled && !Sword)
        {
            Answer[numActiveLights] = SWVal;
            numActiveLights++;
            Sword = true;
        }
        else if (HeartTorch.GetComponentInChildren<Light>().isActiveAndEnabled && !Heart)
        {
            Answer[numActiveLights] = HTVal;
            numActiveLights++;
            Heart = true;
        }
        else if (SkullTorch.GetComponentInChildren<Light>().isActiveAndEnabled && !Skull)
        {
            Answer[numActiveLights] = STVal;
            numActiveLights++;
            Skull = true;
        }

        // If all lights are active, check to see if they match the pattern
        if (numActiveLights == 3)
        {
            if (CheckPuzzle())
            {
                // OPEN DOOR AND DO MAGIC
            }
            else
            {
                numActiveLights = 0;
                // Disable torches and stop animations
                SwordTorch.GetComponentInChildren<Light>().enabled = false;
                SwordTorch.GetComponent<TorchAnimation>().enabled = false;
                SwordTorch.GetComponent<SpriteRenderer>().sprite = NoFlame;

                SkullTorch.GetComponentInChildren<Light>().enabled = false;
                SkullTorch.GetComponent<TorchAnimation>().enabled = false;
                SkullTorch.GetComponent<SpriteRenderer>().sprite = NoFlame;

                HeartTorch.GetComponentInChildren<Light>().enabled = false;
                HeartTorch.GetComponent<TorchAnimation>().enabled = false;
                HeartTorch.GetComponent<SpriteRenderer>().sprite = NoFlame;
                // Possibly a sound effect?
            }
        }
    }

    private bool CheckPuzzle()
    {
        for (int i = 0; i < Answer.Length; i++)
        {
            if (Answer[i] != Puzzle[i])
            {
                return false;
            }
        }
        return true;
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
                gameObject.GetComponentInChildren<Light>().enabled = true;
            }
        }
    }
}
