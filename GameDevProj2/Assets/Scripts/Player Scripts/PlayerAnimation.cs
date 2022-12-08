using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Sprite[] playerFrames;
    public float walkSpeed = 0.5f;

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

    public void OnDisable()
    {
        StopAllCoroutines();
        renderer.sprite = playerFrames[0];
        currentSprite = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayAnimation()
    {
        renderer.sprite = playerFrames[currentSprite];
        currentSprite = (currentSprite + 1) % playerFrames.Length;
        yield return new WaitForSeconds(walkSpeed);
        StartCoroutine(PlayAnimation());
    }
}
