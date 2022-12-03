using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Sprite[] enemyFrames;
    public float walkSpeed = 2.5f;

    new private SpriteRenderer renderer;
    private int currentSprite = 0;

    // Start is called before the first frame update
    void Start()
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
        renderer.sprite = enemyFrames[currentSprite];
        currentSprite = (currentSprite + 1) % enemyFrames.Length;
        yield return new WaitForSeconds(walkSpeed);
        StartCoroutine(PlayAnimation());
    }
}
