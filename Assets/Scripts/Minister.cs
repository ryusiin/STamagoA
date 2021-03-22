using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minister : MonoBehaviour, IObserver_Time
{
    // : Init
    // >> Secretary
    public APPSecretary APPSecretary { get; private set; }
    public SCENESecretary SCENESecretary { get; private set; }
    public DATASecretary DATASecretary { get; private set; }
    public ZOMBIESecretary ZOMBIESecretary { get; private set; }
    public TIMESecretary TIMESecretary { get; private set; }
    public void Init() {
        // :: Secretary
        this.APPSecretary = this.InitSecretary<APPSecretary>();
        this.SCENESecretary = this.InitSecretary<SCENESecretary>();
        this.DATASecretary = this.InitSecretary<DATASecretary>();
        this.ZOMBIESecretary = this.InitSecretary<ZOMBIESecretary>();
        this.TIMESecretary = this.InitSecretary<TIMESecretary>();

        // :: Complete
        this.ScenarioStart();
    }
    private T InitSecretary<T>() where T : Secretary
    {
        T secretary = this.gameObject.AddComponent<T>();
        secretary.Init(this);

        return secretary;
    }

    // : Scenario
    private void ScenarioStart()
    {
        // :: Load
        this.SCENESecretary.LoadScene(Enum.eScene.INTRO);

        // :: Observe
        this.TIMESecretary.RegisterObserver(this);
    }
    // >> Status : Const
    const int CALM_DOWN_SUB_VALUE = -1;
    private void Scenario_EverySecondForCurrentZombie()
    {
        // :: Get
        Enum.eStatus eStatus =
            this.ZOMBIESecretary.Zombie_Current.Get_ZombieStatus();

        // :: EXIT
        if (eStatus != Enum.eStatus.CURRENT)
            return;
        
        // :: Set
        this.ZOMBIESecretary.Zombie_Current.Add_CurDeadlineSecond();
        this.ZOMBIESecretary.Zombie_Current
            .Add_CurCalmDown(CALM_DOWN_SUB_VALUE);
    }

    // :: Observe
    public void UpdateSecond(System.DateTime time)
    {
        this.Scenario_EverySecondForCurrentZombie();
    }
    public void UpdateMinute(System.DateTime time)
    {
        Debug.LogWarning(":: Minister 분 관찰 중");
    }
}
