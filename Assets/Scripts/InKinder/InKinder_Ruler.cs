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
        this.UIChief.AddButtonListener_Release(
            this.ButtonScenario_NoticeReleaseZombie);
    }

    // : Start
    protected override void StartRuler()
    {
        // :: Set
        this.GOChief.Set_ZombieModel(this.curZombie.Get_ModelType());

        // :: Check
        if (this.curZombie.Get_ZombieStatus() == Enum.eZombieStatus.WAIT)
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
        this.curZombie.Change_ZombieStatus(Enum.eZombieStatus.CURRENT);
    }
    private void ButtonScenario_NoticeReleaseZombie()
    {
        this.UIChief.ShowPack_NoticeReleaseZombie(false);

        // :: Zombie
        this.curZombie.Set_ReleaseDate(
            this.minister.TIMESecretary.Time_Current);
        this.curZombie.Change_ZombieStatus(Enum.eZombieStatus.RELEASE);
        this.minister.ZOMBIESecretary
            .AddListZombie_Release(this.curZombie);

        // :: Player
        int gold = this.curZombie.Get_CompleteGold();
        this.minister.PLAYERSecretary.AddGold(gold);

        // :: Update
        this.Scenario_UpdateUI();

        // :: GoTo
        this.Scenario_GoToGotcha();
    }

    // : Scenario
    private void Scenario_NewZombie()
    {
        int nameID = this.curZombie.Get_ZombieNameID();
        string name = this.minister.DATASecretary.DictName[nameID].name;
        int descriptionID = this.curZombie.Get_DescriptionZombieID();
        string description = this.minister.DATASecretary
            .DictDescription_Zombie[descriptionID].description;

        this.UIChief.ShowButton_NoticeNewZombie(true, 
            new Pack_NewZombie(name, description));
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

        // :: Gold
        int curGold = this.minister.PLAYERSecretary.Gold_Current;
        this.UIChief.SetText_Gold(curGold);
    }
    // >> Status
    private bool isNoticeRelease = false;
    private void Scenario_CheckRelease()
    {
        // :: Check
        if (this.isNoticeRelease == true)
            return;
        Enum.eZombieStatus eStatus = this.curZombie.Get_ZombieStatus();
        if (eStatus != Enum.eZombieStatus.RELEASE_WAIT)
            return;

        // :: Set
        this.isNoticeRelease = true;
        this.Scenario_NoticeRelease();
    }
    private void Scenario_NoticeRelease()
    {
        // :: Set
        this.isEnd = true;

        // :: Check
        int trainingPoint = 1;
        Debug.LogWarning("== Training Point로 성공 실패 판정");
        this.curZombie.Set_CompleteStatus(trainingPoint);

        // :: Pack
        Enum.eCompleteStatus eComplete = this.curZombie
            .Get_CompleteStatus();
        int nameID = this.curZombie.Get_ZombieNameID();
        string name = this.minister.DATASecretary.DictName[nameID].name;
        int gold = this.curZombie.Get_CompleteGold();
        Pack_ReleaseZombie pack = new Pack_ReleaseZombie(
            name, gold, eComplete);

        // :: Show
        this.UIChief.ShowPack_NoticeReleaseZombie(true, pack);
    }
    private void Scenario_GoToGotcha()
    {
        this.UIChief.FadeDim(Enum.eFade.OUT, () =>
        {
            this.minister.SCENESecretary.LoadScene(Enum.eScene.GOTCHA);
        });
    }

    // :: Observer Pattern
    // >> Status
    private bool isEnd = false;
    public void UpdateSecond(System.DateTime time)
    {
        if (isEnd)
            return;

        this.Scenario_UpdateUI();
        this.Scenario_CheckRelease();
    }
    public void UpdateMinute(System.DateTime time)
    {

    }
}
