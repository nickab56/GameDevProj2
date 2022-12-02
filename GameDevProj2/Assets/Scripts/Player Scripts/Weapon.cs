using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootPoint;

    private bool inCoolDown = false;

    private AudioSource Blaster;

    // Start is called before the first frame update
    void Start()
    {
        Blaster = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !inCoolDown)
        {
            if (!Blaster.isPlaying)
                Blaster.PlayOneShot(Blaster.clip, 0.5f);
            inCoolDown = true;
            GameObject go = Instantiate(bullet);
            go.transform.position = shootPoint.transform.position;
            go.transform.rotation = shootPoint.transform.rotation;
            TorchSwing b = go.GetComponent<TorchSwing>();
            b.speed = 10;
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(2);
        inCoolDown = false;
    }
}
