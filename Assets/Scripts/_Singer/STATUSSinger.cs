using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STATUSSinger
{
    // : Singleton
    private static STATUSSinger instance = null;
    public static STATUSSinger Instance()
    {
        if (instance == null)
            instance = new STATUSSinger();

        return instance;
    }

    // : Constructor
    public STATUSSinger() { this.Init(); }

    // : Controller
    private INFOController_Zombie INFOController;

    // : Status
    private Class_Zombie Zombie_Current;
    private Info_Zombie Zombie_Current_Info;

    // : Init
    private void Init()
    {
        // :: Controller
        this.INFOController = new INFOController_Zombie();

        // :: Status
        this.Zombie_Current = this.INFOController.GetZombie_Current();
        this.Zombie_Current_Info = this.Zombie_Current.Info;

        // :: Init Complete
        Dictator.Debug_Init(this.ToString());
    }

    // : Sub
    public System.Action Callback_UpdateStatus = null;
    public void AddStatus_CurrentZombie_CalmDown(int stat)
    {
        this.Zombie_Current.AddStatus_CalmDown(stat);
        this.INFOController.Save(this.Zombie_Current_Info);

        // :: Callback
        this.Callback_UpdateStatus.Invoke();
    }

    // : Get
    public Enum.eZombie GetType_CurrentZombie()
    {
        return this.Zombie_Current.Info.type;
    }
    public float GetStatus_CurrentZombie_CalmDown()
    {
        return this.Zombie_Current.GetStatus_CalmDown();
    }
}
