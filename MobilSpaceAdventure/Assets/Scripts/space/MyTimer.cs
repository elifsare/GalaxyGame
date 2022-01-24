using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    private float interval = 1000;
    private bool timerState = false;

    public delegate void TimerTickEventHandler();
    public event TimerTickEventHandler TimerTick;
    private int tick_count = 0;

    public MyTimer()
    {
        this.interval = interval * 0.001f;
    }

    [SerializeField]
    public void setInterval(int i)
    {
        this.interval = i * 0.001f;
    }

    [SerializeField]
    public void timerStart()
    {
        timerState = true;
        StartCoroutine(tick());
    }

    IEnumerator tick()
    {
        while (timerState)
        {
            yield return new WaitForSeconds(this.interval);
            if (TimerTick != null)
            {
                tick_count++;
                TimerTick();
            }
        }
    }

    [SerializeField]
    public void timerStop()
    {
        timerState = false;
    }

    public int getTickCount()
    {
        return this.tick_count;
    }

    public void resetTickCounter()
    {
        this.tick_count = 0;
    }

    public void dinleme()
    {
        this.TimerTick -= TimerTick;
    }
}
