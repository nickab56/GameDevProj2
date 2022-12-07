using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TorchPuzzleNA : MonoBehaviour
{
    public Sprite NoFlame;
    public GameObject doorOpen;

    private GameObject SkullTorch;
    private GameObject HeartTorch;
    private GameObject SwordTorch;
    private GameObject PuzzleDoor;

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
        if (SkullTorch == null)
        {
            Debug.Log("SkullTorch not found");
        }
        HeartTorch = GameObject.FindGameObjectWithTag("HeartTorch");
        if (HeartTorch == null)
        {
            Debug.Log("HeartTorch not found");
        }
        SwordTorch = GameObject.FindGameObjectWithTag("SwordTorch");
        if (SwordTorch == null)
        {
            Debug.Log("SwordTorch not found");
        }
        PuzzleDoor = GameObject.FindGameObjectWithTag("PuzzleDoor");
        if (PuzzleDoor == null)
        {
            Debug.Log("PuzzleDoor not found");
        }
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
                doorOpen = Instantiate(doorOpen);
                doorOpen.transform.position = PuzzleDoor.transform.position;
                Destroy(PuzzleDoor);
                numActiveLights = 0;
            }
            else
            {
                numActiveLights = 0;
                // Disable torches and stop animations
                SwordTorch.GetComponentInChildren<Light>().enabled = false;
                SwordTorch.GetComponent<TorchAnimation>().enabled = false;
                SwordTorch.GetComponent<SpriteRenderer>().sprite = NoFlame;
                Sword = false;

                SkullTorch.GetComponentInChildren<Light>().enabled = false;
                SkullTorch.GetComponent<TorchAnimation>().enabled = false;
                SkullTorch.GetComponent<SpriteRenderer>().sprite = NoFlame;
                Skull = false;

                HeartTorch.GetComponentInChildren<Light>().enabled = false;
                HeartTorch.GetComponent<TorchAnimation>().enabled = false;
                HeartTorch.GetComponent<SpriteRenderer>().sprite = NoFlame;
                Heart = false;
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
