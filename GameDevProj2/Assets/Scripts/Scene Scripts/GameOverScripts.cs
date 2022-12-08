using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScripts : MonoBehaviour
{
    public GameObject tear;

    public Vector3 tearLeftPos;
    public Vector3 tearRightPos;

    public TMP_Text PlayerTimeTxt;
    public TMP_Text HighTimeTxt;

    // Start is called before the first frame update
    void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "GameOverDeathScene")
        {
            PlayerTimeTxt.text = "Time   " + Constants.C.timeCount.ToString("0.00");
            HighTimeTxt.text = "Best Time   " + Constants.C.HighTime.ToString("0.00");
        } else
        {

            StartCoroutine(DelayDrop(tearRightPos));
            StartCoroutine(SpawnTear(tearLeftPos));
        }
    }

    // Update is called once per frame
    void Update()
    {
        WaitResponse();
    }

    void WaitResponse()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SplashScene");
        }

    }

    IEnumerator SpawnTear(Vector3 pos)
    {
        GameObject newTear = Instantiate(tear);
        newTear.transform.position = pos;
        yield return new WaitForSeconds(0.45f);
        StartCoroutine(SpawnTear(pos));
    }

    IEnumerator DelayDrop(Vector3 pos)
    {
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(SpawnTear(pos));
    }
}
