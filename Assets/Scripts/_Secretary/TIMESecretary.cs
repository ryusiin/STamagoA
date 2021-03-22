using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIMESecretary : Secretary, ISubject_Time
{
    // : Init
    // >> Status
    public DateTime curTime;
    // >> Observer
    private List<IObserver_Time> listObservers;
    public override void Init(Minister Minister)
    {
        base.Init(Minister);

        // :: Use
        this.listObservers = new List<IObserver_Time>();

        // :: Status
        this.curTime = DateTime.Now;
    }

    // : Update
    // >> Status
    private int curSecond = 0;
    private void Update()
    {
        this.curTime = DateTime.Now;
        if (this.curSecond != this.curTime.Second)
            this.Scenario_EverySeconds();
    }

    // : Scenario
    private void Scenario_EverySeconds()
    {
        // :: Set
        this.curSecond = this.curTime.Second;

        // :: Do
        this.Notify_EverySecond();

        // :: Check Minute
        if (this.curSecond == 0)
            this.Scenaro_EveryMinutes();
    }
    private void Scenaro_EveryMinutes()
    {
        // :: Do
        this.Notify_EveryMinute();
    }

    // :: Observer Pattern
    public void RegisterObserver(IObserver_Time observer)
    {
        if (!this.listObservers.Contains(observer))
            this.listObservers.Add(observer);
    }
    public void RemoveObserver(IObserver_Time observer)
    {
        if (this.listObservers.Contains(observer))
            this.listObservers.Remove(observer);
    }
    public void Notify_EverySecond()
    {
        foreach (IObserver_Time observer in this.listObservers)
            observer.UpdateSecond(this.curTime);
    }
    public void Notify_EveryMinute()
    {
        foreach (IObserver_Time observer in this.listObservers)
            observer.UpdateMinute(this.curTime);
    }
}
