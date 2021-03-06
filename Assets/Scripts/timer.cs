﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class timer : MonoBehaviour
{
    public int timerTime;
    public int lowTime;
    public Color normalColor;
    public Color lowColor;
    public Text timerText;
    public UnityEvent onTimerZero;
    public AudioClip clip;

    float time;
    string lastFrameTime;
    void Start()
    {
        //setting up
        time = timerTime;
        timerText.color = normalColor;
        //checking if the time has been set up, and if not changing the lowTime
        if (lowTime > timerTime)
            lowTime = timerTime;
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timerText.text = time.ToString("0");
        }

        if (time.ToString("0") == lowTime.ToString("0"))
            timerText.color = lowColor;

        if (time <= 0)
        {
            //Debug.Log("Time's Up!");
            onTimerZero.Invoke();
            Destroy(gameObject);
        }
        if (timerText.color == lowColor && lastFrameTime != time.ToString("0"))
        {
            FindObjectOfType<soundPlayer>().playSound(clip);
        }
        lastFrameTime = time.ToString("0");
    }
}
