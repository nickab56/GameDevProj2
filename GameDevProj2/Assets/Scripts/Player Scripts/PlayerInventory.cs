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
    private PuzzleScrollUI PSUI;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        keyUI = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<KeyUI>();
        PSUI = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<PuzzleScrollUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Scroll)
        {
            script = this.GetComponent<PlayerMovement>();
            script.enabled = false;
            PlayerCrosshair.enabled = false;
            
            if (i == 0)
            {
                // Enable canvas texts
                PSUI.ToggleScroll(true);
                PSUI.UpdateText("Three torches must be lit to pass deeper into the dungeon\r\nBut only the wise may do so\r\nProve your prudence and answer this riddle\r\n", 0);
                i++;
            }
            if (i == 1 && Input.GetKeyDown(KeyCode.D))
            {
                PSUI.UpdateText("To be or not to be is the question\r\nBut with me, my owner is no longer being\r\nFor I am wholly absent of flesh\r\nAnd I lack that which I once protected\r\n", 1);
                i++;
                audio.Play();
            }
            else if (i == 2 && Input.GetKeyDown(KeyCode.D))
            {
                PSUI.UpdateText("I beat more than I'm beaten,\r\nThough I have been known to break.\r\nI can be made of gold or stone,\r\nYet still get sick and ache.\r\n", 2);
                i++;
                audio.Play();
            }
            else if (i == 3 && Input.GetKeyDown(KeyCode.D))
            {
                PSUI.UpdateText("They say the pen is mightier than me\r\nBut do not believe such jest\r\nFor I cut deeper than fools’ words\r\nAnd I can draw just the same\r\n", 3);
                i++;
                audio.Play();
            }
        }

        if (Scroll && Input.GetKey(KeyCode.X))
        {
            audio.Play();
            Scroll = false;
            PSUI.ToggleScroll(false);
            script.enabled = true;
            PlayerCrosshair.enabled = true;
            i = 0;
        }

        if (Key)
        {
            keyUI.SetKey(Key);
        }
    }

}
