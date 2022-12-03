using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool Torch = false;
    public bool Key = false;
    public bool Torchbool = false;
    public Light TorchLight;

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
    }

}
