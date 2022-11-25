using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPickUp : MonoBehaviour
{
    public GameObject Player;
    public PlayerInventory PlayerInventory;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerInventory = Player.GetComponent<PlayerInventory>();
            PlayerInventory.Torch = true;
            Destroy(this.gameObject);
        }
    }
}
