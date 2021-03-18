using System;

public class DATASecretary : Secretary_Public
{
    // : Engineer
    private DATA_ZOMBIEEngineer ZOMBIEEngineer;
    private DATA_FOODEngineer FOODEngineer;

    // : Init
    public override void Init()
    {
        // : Engineer
        this.ZOMBIEEngineer = new DATA_ZOMBIEEngineer();
        this.ZOMBIEEngineer.InitMinister(this.Minister);
        this.FOODEngineer = new DATA_FOODEngineer();
        this.FOODEngineer.InitMinister(this.Minister);

        // :: Complete
        Clerk.Log(Enum.eLog.INIT, this.ToString());
    }

    // : Get
    public DateTime GetTime_Last()
    {
        return this.INFOSecretary.GetPlayerTime_Last();
    }
    public DateTime GetTime_Current()
    {
        return this.TIMESecretary.GetTime_Current();
    }
    public DATAZombie GetData_Zombie(Enum.eZombie eZombie)
    {
        return this.ZOMBIEEngineer.DictZombie[eZombie];
    }
    public DATAFood GetData_Food(Enum.eFood eFood)
    {
        return this.FOODEngineer.DictFood[eFood];
    }
    private Class_Zombie Zombie_Current;
    public Class_Zombie GetZombie_Current()
    {
        if (this.Zombie_Current == null)
            this.Zombie_Current = this.INFOSecretary.GetZombie_Current();

        return this.Zombie_Current;
    }
    public float GetRemainDeadline_CurrentZombie()
    {
        if (this.Zombie_Current == null)
            this.Zombie_Current = this.INFOSecretary.GetZombie_Current();

        DateTime startTime = this.Zombie_Current.Info.time_start;
        DateTime curTime = this.GetTime_Current();

        TimeSpan gap = curTime - startTime;
        int deadline = this.Zombie_Current.GetMinutes_Deadline();
        float remains = (float)gap.TotalMinutes / deadline;

        return remains;
    }
}
