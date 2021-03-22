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
        this.Info.cur_deadline_second = 0;
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

    // : Get
    public Enum.eZombie Get_ModelType()
    {
        return this.Data.model_type;
    }
    public Enum.eStatus Get_ZombieStatus()
    {
        return this.Info.eStatus;
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

    // : Change
    public void Change_ZombieStatus(Enum.eStatus eStatus)
    {
        this.Info.eStatus = eStatus;
    }
}
