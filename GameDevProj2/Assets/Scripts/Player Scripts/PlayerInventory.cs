using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public bool Torch = false;
    public bool Key = false;
    public bool Torchbool = false;
    public bool Scroll = false;
    public Light TorchLight;

    public TMP_Text ScrollText;
    public TMP_Text PickupText;
    public Crosshair PlayerCrosshair;
    public GameObject Player;

    PlayerMovement script;

    // Start is called before the first frame update
    void Start()
    {
        
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
            script = Player.GetComponent<PlayerMovement>();
            script.enabled = false;
            PlayerCrosshair.enabled = false;
        }

        if (Scroll && Input.GetKey(KeyCode.X))
        {
            Time.timeScale++;
            Scroll = false;
            script.enabled = true;
            PlayerCrosshair.enabled = true;

        }
    }

}
