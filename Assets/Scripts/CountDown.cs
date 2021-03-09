using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public GameObject defeat;
    public static float timeLeft;
    public static float time;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        text.text = "\n" + Mathf.Round(timeLeft);
        time = 5;
        timeLeft = time;
    }

    void Update()
    {

        if (timeLeft < 0)
        {
            text.text = "\n Time Over !!!";
            defeat.SetActive(true);
            //Application.LoadLevel("gameOver");
        }
        else
        {
            timeLeft -= Time.deltaTime;
            text.text = "\n" + Mathf.Round(timeLeft);
        }
    }
}
