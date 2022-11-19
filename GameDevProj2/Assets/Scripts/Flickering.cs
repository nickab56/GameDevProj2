using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour
{
    public float intensityRange;

    private Light lightRenderer;
    private float originalIntensity;

    // Start is called before the first frame update
    void Start()
    {
        lightRenderer = this.GetComponent<Light>();
        originalIntensity = lightRenderer.intensity;
        StartCoroutine(Flicker());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Flicker()
    {
        yield return new WaitForSeconds(Random.Range(0.01f, 0.5f));
        float waitTime;
        while (true)
        {
            float randomIntensity = Random.Range(originalIntensity - intensityRange, originalIntensity + intensityRange);
            lightRenderer.intensity = randomIntensity;
            waitTime = Random.Range(0.07f, 0.12f);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
