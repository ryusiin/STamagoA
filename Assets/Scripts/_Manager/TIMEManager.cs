using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;

public class TIMEManager : MonoBehaviour
{
    // : Const
    const string TIME_SERVER_URL = "http://www.google.com";

    // : Init
    private DateTime initTime;
    private DateTime addingTime;
    public void Init()
    {
        this.initTime = this.GetInitTime();
        this.addingTime = this.initTime;

        this.startUpdateTime = true;
    }

    // : Get
    private DateTime GetInitTime()
    {
        // :: Set
        DateTime initTime;
        try
        {
            var response = WebRequest.Create(TIME_SERVER_URL).GetResponse();
            initTime = DateTime.Parse(response.Headers["date"]);
        }
        catch (Exception err)
        {
            Dictator.Debug_Error(Enum.eError.NETWORK_CONNECTION_FAILED);
            Debug.Log(err);
            initTime = DateTime.Now;
        }

        // :: Return
        return initTime;
    }
    public DateTime GetCurTime()
    {
        return this.addingTime;
    }

    // : Update
    private bool startUpdateTime = false;
    private float checkTime = 0;
    private int checkSecond = 0;
    private int curSecond = 0;
    private void Update()
    {
        if(this.startUpdateTime)
        {
            this.UpdateTime(Time.deltaTime);
        }
    }
    public System.Action<DateTime> Callback_ReachedMinute;
    private void UpdateTime(float deltaTime)
    {
        this.checkTime += deltaTime;
        this.checkSecond = (int)Math.Truncate(this.checkTime);
        if (this.curSecond != this.checkSecond)
        {
            this.curSecond = this.checkSecond;

            // :: Get
            this.addingTime = this.initTime.AddSeconds(this.checkTime);
            if (this.addingTime.Second == 0)
                this.Callback_ReachedMinute(this.addingTime);
        }
    }
}
