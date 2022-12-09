using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleScrollUI : MonoBehaviour
{
    public RawImage TextScroll;
    public TMP_Text CloseTxt;
    public TMP_Text DownTxt;
    public TMP_Text ScrollTxt;

    public bool isScrollActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleScroll(bool isActive)
    {
        isScrollActive = isActive;
        TextScroll.enabled = isActive;
        CloseTxt.enabled = isActive;
        DownTxt.enabled = isActive;
        ScrollTxt.enabled = isActive;
    }

    public void UpdateText(string Txt, int i)
    {
        ScrollTxt.text = Txt;
        if (i == 3)
        {
            DownTxt.enabled = false;
        }
    }
}
