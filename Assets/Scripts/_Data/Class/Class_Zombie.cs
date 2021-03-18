using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class_Zombie
{
    // : Status
    public Info_Zombie Info { get; private set; }
    private DATAZombie data;

    // : Constructor
    public Class_Zombie(DATAZombie data)
    {
        // :: Get
        this.data = data;

        // :: Init
        this.Info = new Info_Zombie();
        this.Info.guid = Guid.NewGuid().ToString();
        this.Info.type = (Enum.eZombie)this.data.id;
        this.Info.status = Enum.eStatus.WAITING;
        this.Info.current_training_point = 0;
        this.Info.current_calm_down = this.data.max_calm_down / 2;
    }

    // : Init
    public void Init(DateTime curTime)
    {
        this.Info.time_start = curTime;
    }

    // : Change
    public void ChangeInfo(Info_Zombie info)
    {
        this.Info = info;
    }

    // : Get
    public float GetStatus_CalmDown()
    {
        float percent = this.Info.current_calm_down / (float)this.data.max_calm_down;
        return percent;
    }
    public float GetStatus_Training()
    {
        float percent = this.Info.current_training_point / (float)this.data.required_training_point;
        return percent;
    }
    public int GetMinutes_Deadline()
    {
        return this.data.deadline_minute;
    }

    // : Add
    public void AddStatus_CalmDown(int stat)
    {
        // :: Add
        this.Info.current_calm_down += stat;

        // :: Stabilize
        if (this.Info.current_calm_down < 0)
            this.Info.current_calm_down = 0;
        if (this.Info.current_calm_down > this.data.max_calm_down)
            this.Info.current_calm_down = this.data.max_calm_down;
    }
}
