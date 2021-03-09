﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CountDown : MonoBehaviour
{

    public static float timeLeft;
    public static float time;
    AudioSource audioClock;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        text.text = "\n" + Mathf.Round(timeLeft);
        time = 100;
        timeLeft = time;
        audioClock = GameObject.Find("Audio Clock").GetComponent<AudioSource>();
    }

    void Update()
    {

        if (timeLeft < 0)
        {
            text.text = "\n Time Over !!!";
            audioClock.Stop();
            //Application.LoadLevel("gameOver");
        }
        else
        {
            timeLeft -= Time.deltaTime;
            text.text = "\n" + Mathf.Round(timeLeft);
        }
    }
}
