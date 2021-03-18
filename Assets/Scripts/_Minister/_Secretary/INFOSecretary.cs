using System;

public class INFOSecretary : Secretary
{
    // : Engineer
    private INFO_PLAYEREngineer PLAYEREngineer;
    private INFO_ZOMBIEEngineer ZOMBIEEngineer;

    // : Init
    public override void Init()
    {
        // :: Engineer
        this.PLAYEREngineer = new INFO_PLAYEREngineer();
        this.PLAYEREngineer.InitMinister(this.Minister);
        this.ZOMBIEEngineer = new INFO_ZOMBIEEngineer();
        this.ZOMBIEEngineer.InitMinister(this.Minister);

        // :: Complete
        Clerk.Log(Enum.eLog.INIT, this.ToString());
    }

    // : Get
    public Class_Zombie GetZombie_Current()
    {
        return this.ZOMBIEEngineer.GetZombie_Current();
    }
    public DateTime GetPlayerTime_Last()
    {
        return this.PLAYEREngineer.GetTime_Last();
    }

    // : Save
    public void SaveZombie()
    {
        Class_Zombie zombie = this.GetZombie_Current();
        this.ZOMBIEEngineer.Save(zombie.Info);
    }

    // : Set
    public void SetPlayerTime_Last(DateTime time)
    {
        this.PLAYEREngineer.SetDate_Last(time);
    }
}
