using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{

    public bool hasKey = false;
    public Image keyUI;

    // Start is called before the first frame update
    void Start()
    {
        keyUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetKey(bool _hasKey)
    {
        hasKey = _hasKey;
        keyUI.enabled = hasKey;
    }
}
