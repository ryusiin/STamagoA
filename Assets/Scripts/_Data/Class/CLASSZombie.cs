using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
        this.Change_ZombieStatus(Enum.eZombieStatus.WAIT);
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
            this.Change_ZombieStatus(Enum.eZombieStatus.RELEASE_WAIT);
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

    // : Change
    public void Change_ZombieStatus(Enum.eZombieStatus eStatus)
    {
        this.Info.eStatus = eStatus;
    }
    public void Change_ZombieCondition(Enum.eCondition eCondition)
    {
        this.Info.eCondition = eCondition;
    }

    // : Get
    public Enum.eZombie Get_ModelType()
    {
        return this.Data.model_type;
    }
    public Enum.eZombieStatus Get_ZombieStatus()
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
    public int Get_CompleteGold()
    {
        if (this.Info.eComplete == Enum.eCompleteStatus.SUCCESS)
            return this.Data.gold_success;
        else
            return this.Data.gold_fail;
    }
    public Enum.eCompleteStatus Get_CompleteStatus()
    {
        return (Enum.eCompleteStatus)this.Info.eComplete;
    }
    public int Get_DescriptionZombieID()
    {
        return this.Data.description_id;
    }
    public int Get_DescriptionCompleteID(Enum.eCompleteStatus eComplete)
    {
        if (eComplete == Enum.eCompleteStatus.SUCCESS)
            return this.Data.description_succss_id;
        else
            return this.Data.description_fail_id;
    }

    // : Set
    public void Set_ReleaseDate(DateTime time)
    {
        this.Info.releaseDate = time;
    }
    public void Set_CompleteStatus(int trainingPoint)
    {
        if (trainingPoint > 0)
            this.Info.eComplete = Enum.eCompleteStatus.SUCCESS;
        else
            this.Info.eComplete = Enum.eCompleteStatus.FAIL;
    }
}
