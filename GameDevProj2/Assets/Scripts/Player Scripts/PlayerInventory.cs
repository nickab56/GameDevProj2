using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.U2D.Animation;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public bool Torch = false;
    public bool Key = false;
    public bool Torchbool = false;
    public bool Scroll = false;
    public Light TorchLight;
    public bool ScrollSpawn = false;

    //public TMP_Text ScrollText;
    //public TMP_Text PickupText;
    public Crosshair PlayerCrosshair;
    public GameObject TextScroll;

    private GameObject TextScrollClone;
    private int i = 0;

    private PlayerMovement script;
    
    private KeyUI keyUI;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        keyUI = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<KeyUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Torch == true && Torchbool == false)
        //{
        //    Instantiate(TorchLight,transform);

        //    Torchbool = true;
        //}

        if (Scroll)
        {
            script = this.GetComponent<PlayerMovement>();
            script.enabled = false;
            PlayerCrosshair.enabled = false;
            
            //Vector2 spawnPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
            if (i == 0)
            {
                Instantiate(TextScroll);
                TextScroll.transform.position = this.transform.position;
                TextScroll.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(.5f, .5f, -1f));
                TextScroll.transform.position = new Vector3(TextScroll.transform.position.x, TextScroll.transform.position.y, -1f);
                TextScrollClone = GameObject.FindWithTag("TextScroll");
                TextScrollClone.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().text = "Three torches must be lit to pass deeper into the dungeon\r\nBut only the wise may do so\r\nProve your prudence and answer this riddle\r\n";
                i++;
            }
            if (i == 1 && Input.GetKeyDown(KeyCode.D))
            {
                TextScrollClone.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().text = "To be or not to be is the question\r\nBut with me, my owner is no longer being\r\nFor I am wholly absent of flesh\r\nAnd I lack that which I once protected\r\n";
                i++;
                audio.Play();
            }
            else if (i == 2 && Input.GetKeyDown(KeyCode.D))
            {
                TextScrollClone.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().text = "I beat more than I'm beaten,\r\nThough I have been known to break.\r\nI can be made of gold or stone,\r\nYet still get sick and ache.\r\n";
                i++;
                audio.Play();
            }
            else if (i == 3 && Input.GetKeyDown(KeyCode.D))
            {
                TextScrollClone.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().text = "They say the pen is mightier than me\r\nBut do not believe such jest\r\nFor I cut deeper than fools� words\r\nAnd I can draw just the same\r\n";
                i++;
                audio.Play();
            }
        }

        if (Scroll && Input.GetKey(KeyCode.X))
        {
            audio.Play();
            Scroll = false;
            script.enabled = true;
            PlayerCrosshair.enabled = true;
            Destroy(TextScrollClone);
            i = 0;
        }

        if (Key)
        {
            keyUI.SetKey(Key);
        }
    }

}
