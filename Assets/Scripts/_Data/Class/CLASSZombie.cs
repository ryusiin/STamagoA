using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLASSZombie
{
    // : Constructor
    // >> Data
    private INFOZombie Info;
    private DATAZombie Data;
    public CLASSZombie(DATAZombie data)
    {
        // :: Use
        this.Data = data;
        this.Info = new INFOZombie();

        // :: Init
        this.Change_ZombieStatus(Enum.eStatus.WAIT);
        this.Change_ZombieCondition(Enum.eCondition.NORMAL);
        this.Info.cur_deadline_second = 0;
        this.Info.cur_calm_down = this.Data.max_calm_down;
    }

    // : Add
    public void Add_CurDeadlineSecond(int second = 1)
    {
        // :: Add
        this.Info.cur_deadline_second += 1;

        // :: Check
        if (this.Info.cur_deadline_second >= this.Data.deadline_second)
            this.Change_ZombieStatus(Enum.eStatus.RELEASE_WAIT);
    }
    public void Add_CurCalmDown(int second = 1)
    {
        // :: Add
        this.Info.cur_calm_down += second;

        // :: Adjust
        if (this.Info.cur_calm_down < 0)
            this.Info.cur_calm_down = 0;
        if (this.Info.cur_calm_down > this.Data.max_calm_down)
            this.Info.cur_calm_down = this.Data.max_calm_down;

        // :: Check
        if (this.Info.cur_calm_down <= 0)
            this.Change_ZombieCondition(Enum.eCondition.CRAZY);
        else
            this.Change_ZombieCondition(Enum.eCondition.NORMAL);
    }

    // : Get
    public Enum.eZombie Get_ModelType()
    {
        return this.Data.model_type;
    }
    public Enum.eStatus Get_ZombieStatus()
    {
        return this.Info.eStatus;
    }
    public Enum.eCondition Get_ZombieCondition()
    {
        return this.Info.eCondition;
    }
    public int Get_ZombieNameID()
    {
        return this.Data.name_id;
    }
    public int Get_CurDeadlineSecond()
    {
        return this.Info.cur_deadline_second;
    }
    public int Get_DeadlineSecond()
    {
        return this.Data.deadline_second;
    }
    public int Get_CurCalmDown()
    {
        return this.Info.cur_calm_down;
    }
    public int Get_MaxCalmDown()
    {
        return this.Data.max_calm_down;
    }

    // : Change
    public void Change_ZombieStatus(Enum.eStatus eStatus)
    {
        this.Info.eStatus = eStatus;
    }
    public void Change_ZombieCondition(Enum.eCondition eCondition)
    {
        this.Info.eCondition = eCondition;
    }
}
