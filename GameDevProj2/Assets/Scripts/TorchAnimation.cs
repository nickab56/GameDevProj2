using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAnimation : MonoBehaviour
{

    public Sprite[] torchFrames;
    public float flameSpeed = 0.5f;

    new private SpriteRenderer renderer;
    private int currentSprite = 0;

    // Start is called before the first frame update
    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        StartCoroutine(PlayAnimation());
    }

    private void OnEnable()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        StartCoroutine(PlayAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayAnimation()
    {
        renderer.sprite = torchFrames[currentSprite];
        currentSprite = (currentSprite + 1) % torchFrames.Length;
        yield return new WaitForSeconds(flameSpeed);
        StartCoroutine(PlayAnimation());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        renderer.sprite = torchFrames[0];
        currentSprite = 0;
    }
}
