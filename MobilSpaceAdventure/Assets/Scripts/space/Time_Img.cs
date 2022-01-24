using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Img : MonoBehaviour
{
    private int time;

    public Image image;

    public List<Sprite> sprites = new List<Sprite>();

    private MyTimer timer;

    private bool timer_started = false;

    void Start()
    {
        timer = FindObjectOfType<MyTimer>();
        if (!timer_started)
        {
            timer.TimerTick += Timer_TimerTick;
            timer.timerStart();
            timer_started = true;
        }
    }

    void Timer_TimerTick()
    {
        time++;
        int a = time % 24;
        image.sprite = sprites[a];
    }
}
