using System;
using System.Collections.Generic;
using UnityEngine;

public class POLICYSecretary : Secretary_Public, IPolicy
{
    // : Observer
    private List<IObserver_Policy> listObservers_Policy;

    // : Init
    public override void Init()
    {
        // :: Use
        this.listObservers_Policy = new List<IObserver_Policy>();

        // :: Complete
        Clerk.Log(Enum.eLog.INIT, this.ToString());
    }

    // :: Add
    private void AddStatus_CalmDown_CurrentZombie(int status)
    {
        // :: Get
        Class_Zombie zombie = this.DATASecretary.GetZombie_Current();

        // :: Set
        zombie.AddStatus_CalmDown(status);

        // :: Save
        this.INFOSecretary.SaveZombie();

        // :: Notify
        this.NotifyObservers_UpdateStatus();
    }

    // : Policy
    public void PolicyStart()
    {
        // :: Get
        DateTime lastTime = this.DATASecretary.GetTime_Last();
        DateTime curTime = this.DATASecretary.GetTime_Current();
        TimeSpan gapTime = curTime - lastTime;

        // :: Sub
        int gap = (int)gapTime.TotalMinutes;
        this.AddStatus_CalmDown_CurrentZombie(-gap);

        // :: 깎고 남은만큼 Training 치를 깎는다.
        Debug.Log("***** 깎고 남은만큼 Training 치를 깎는다.");
    }
    public void PolicyEat_CurrentZombie(Enum.eFood eFood)
    {
        // :: Get
        int calmDown = this.DATASecretary.GetData_Food(eFood).calm_down;

        // :: Do
        this.AddStatus_CalmDown_CurrentZombie(calmDown);
    }
    const int REDUCE_STATUS_CALM_DOWN = -1;
    public void PolicyDo_EveryMintues()
    {
        // :: Set
        DateTime curTime = this.DATASecretary.GetTime_Current();
        this.INFOSecretary.SetPlayerTime_Last(curTime);

        // :: DO
        this.AddStatus_CalmDown_CurrentZombie(REDUCE_STATUS_CALM_DOWN);
    }

    // : Observer Pattern
    public void RegisterObserver(IObserver_Policy observer)
    {
        this.listObservers_Policy.Add(observer);
    }
    public void RemoveObserver(IObserver_Policy observer)
    {
        if (this.listObservers_Policy.Contains(observer))
            this.listObservers_Policy.Remove(observer);
    }
    // >> Notify
    public void NotifyObservers_UpdateStatus()
    {
        foreach (IObserver_Policy observer in this.listObservers_Policy)
            observer.UpdatePolicy_Status();
    }
}
