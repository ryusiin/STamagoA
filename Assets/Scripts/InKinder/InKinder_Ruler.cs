using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InKinder_Ruler : Ruler, IObserver_Time
{
    // : Init
    // >> Chief
    private InKinder_UIChief UIChief;
    private InKinder_GOChief GOChief;
    // >> Status
    private CLASSZombie curZombie;
    protected override void InitChief()
    {
        this.UIChief = GameObject.FindObjectOfType<InKinder_UIChief>();
        this.UIChief.Init();
        this.GOChief = GameObject.FindObjectOfType<InKinder_GOChief>();
        this.GOChief.Init();
    }
    protected override void InitStatus()
    {
        this.curZombie = this.minister.ZOMBIESecretary.Zombie_Current;
    }
    protected override void InitButtons()
    {
        this.UIChief.AddButtonListener_NoticeNewZombie(
            this.ButtonScenario_NoticeNewZombie);
    }

    // : Start
    protected override void StartRuler()
    {
        // :: Set
        this.GOChief.Set_ZombieModel(this.curZombie.Get_ModelType());

        // :: Check
        if (this.curZombie.Get_ZombieStatus() == Enum.eStatus.WAIT)
            this.Scenario_NewZombie();

        // :: Observe
        this.minister.TIMESecretary.RegisterObserver(this);

        // :: UI
        this.Scenario_InitUI();
        this.Scenario_UpdateUI();

        // :: Fade
        this.UIChief.FadeDim(Enum.eFade.IN);
    }

    // : Button Scenario
    private void ButtonScenario_NoticeNewZombie()
    {
        this.UIChief.ShowButton_NoticeNewZombie(false);
    }

    // : Scenario
    private void Scenario_NewZombie()
    {
        int nameID = this.curZombie.Get_ZombieNameID();
        string name = this.minister.DATASecretary.DictName[nameID].name;

        this.UIChief.ShowButton_NoticeNewZombie(true, name);
        this.curZombie.Change_ZombieStatus(Enum.eStatus.CURRENT);
    }
    private void Scenario_InitUI()
    {
        this.UIChief.SetSlider_Deadline(
            this.curZombie.Get_DeadlineSecond());
    }
    private void Scenario_UpdateUI()
    {
        // :: Deadline
        this.UIChief.ChangeSlider_Deadline(
            this.curZombie.Get_CurDeadlineSecond());

        // :: CalmDown
        int curCalmDown = this.curZombie.Get_CurCalmDown();
        int maxCalmDown = this.curZombie.Get_MaxCalmDown();
        this.UIChief.SetUI_CalmDown(curCalmDown, maxCalmDown);
    }

    // :: Observer Pattern
    public void UpdateSecond(System.DateTime time)
    {
        this.Scenario_UpdateUI();
    }
    public void UpdateMinute(System.DateTime time)
    {

    }
}
