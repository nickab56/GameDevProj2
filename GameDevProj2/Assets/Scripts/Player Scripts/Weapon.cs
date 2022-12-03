using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootPoint;
    public int speed =3;

    private bool inCoolDown = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !inCoolDown)
        {
            inCoolDown = true;
            GameObject go = Instantiate(bullet,transform);
            go.transform.position = shootPoint.transform.position;
            go.transform.rotation = shootPoint.transform.rotation;
            go.transform.Rotate(0f, 0f, 90f);
            TorchSwing b = go.GetComponent<TorchSwing>();
            b.speed = speed;
            
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(2);
        inCoolDown = false;
    }
}
