using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScriptNA : MonoBehaviour
{
    public bool hitting = false;
    public bool inCoolDown = false;
    public GameObject Weapon;

    private float coolDown = 2f;
    private float hitTime = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inCoolDown == false)
        {
            hitting = true;
            inCoolDown = true;
            StartCoroutine(CoolDownTime());
            StartCoroutine(HitTime());

            Instantiate(Weapon);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.tag == "Enemy" && hitting == true)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator CoolDownTime()
    {
        yield return new WaitForSeconds(coolDown);
        inCoolDown = false;
    }

    IEnumerator HitTime()
    {
        yield return new WaitForSeconds(hitTime);
        hitting = false;
    }

}
