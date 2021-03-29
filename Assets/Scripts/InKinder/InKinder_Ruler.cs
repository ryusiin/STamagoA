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
        // :: Status
        this.UIChief.Init_FoodButtons(this.minister.DATASecretary.DictFood,
            this.ButtonScenario_Foods);
        this.UIChief.Init_OX(this.Scenario_EndOXGame);

        // :: Scenario
        this.UIChief.AddButtonListener_NoticeNewZombie(
            this.ButtonScenario_NoticeNewZombie);
        this.UIChief.AddButtonListener_Release(
            this.ButtonScenario_NoticeReleaseZombie);
        this.UIChief.AddButtonListener_Food(
            this.ButtonScenario_Food);
        this.UIChief.AddButtonListener_Training(
            this.ButtonScenario_Training);
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
        this.Scenario_Update();

        // :: Fade
        this.UIChief.FadeDim(Enum.eFade.IN);
    }

    // : Button Scenario
    private void ButtonScenario_Food()
    {
        bool check = this.UIChief.GetIsActive_FieldFood();
        this.UIChief.ShowField_Food(!check);

        // :: UI
        if (check)
            this.Scenario_Update();
    }
    private void ButtonScenario_Foods(Enum.eFood eFood)
    {
        // :: Get
        DATAFood food = this.minister.DATASecretary.DictFood[(int)eFood];

        // :: Pay
        bool check = this.minister.PLAYERSecretary.PayGold(food.price);
        if(check)
        {
            // :: UI
            this.Scenario_Update();
            this.UIChief.ShowField_Food(false);
            this.UIChief.CanTouchButton_All(false);

            // :: GO
            this.GOChief.Show_Food(eFood);
            this.GOChief.Blink_Alert();

            // :: Animation
            this.GOChief.Set_EndEat(() =>
            {
                // :: GO
                this.GOChief.Hide_Food();

                // :: Status
                this.curZombie.Add_CurCalmDown(food.calm_down);
                this.Scenario_Update();
            });
            this.GOChief.Set_EndAnimation(() =>
            {
                // :: UI
                this.UIChief.CanTouchButton_All(true);
            });
            this.Do_NextSeconds(() =>
            {
                this.GOChief.DoAnimation_Zombie(Enum.eAnimation.EAT);
            }, 0.5f);
        }
    }
    private void ButtonScenario_NoticeNewZombie()
    {
        this.UIChief.ShowField_NoticeNewZombie(false);
        this.curZombie.Change_ZombieStatus(Enum.eZombieStatus.CURRENT);
    }
    private void ButtonScenario_NoticeReleaseZombie()
    {
        this.UIChief.ShowField_NoticeReleaseZombie(false);

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
        this.Scenario_Update();

        // :: GoTo
        this.Scenario_GoToGotcha();
    }
    private void ButtonScenario_Training()
    {
        this.UIChief.ShowField_OX(true, this.minister.DATASecretary.DictOX);
    }

    // : Scenario
    private void Scenario_EndOXGame(int score)
    {
        // :: UI
        this.UIChief.ShowField_OX(false);

        // :: Add
        this.curZombie.Add_CurTrainingPoint(score);

        // :: Update
        this.Scenario_Update();
    }
    private void Scenario_InitUI()
    {
        this.UIChief.SetSlider_Deadline(
            this.curZombie.Get_CurDeadlineSecond(),
            this.curZombie.Get_DeadlineSecond());
    }
    private void Scenario_Update()
    {
        this.Scenario_UpdateUI();
        this.Scenario_UpdateGO();
    }
    private void Scenario_NewZombie()
    {
        int nameID = this.curZombie.Get_ZombieNameID();
        string name = this.minister.DATASecretary.DictName[nameID].name;
        int descriptionID = this.curZombie.Get_DescriptionZombieID();
        string description = this.minister.DATASecretary
            .DictDescription_Zombie[descriptionID].description;

        this.UIChief.ShowField_NoticeNewZombie(true,
            new Pack_NewZombie(name, description));
    }
    private void Scenario_UpdateGO()
    {
        Enum.eCondition eCondition = this.curZombie.Get_ZombieCondition();
        if (eCondition == Enum.eCondition.CRAZY)
            this.GOChief.DoAnimation_Zombie(Enum.eAnimation.CRAZY);
        else if (eCondition == Enum.eCondition.NORMAL)
            this.GOChief.DoAnimation_Zombie(Enum.eAnimation.IDLE);
    }
    private void Scenario_UpdateUI()
    {
        // :: Deadline
        this.UIChief.SetSlider_Deadline(
            this.curZombie.Get_CurDeadlineSecond(),
            this.curZombie.Get_DeadlineSecond());

        // :: Training
        this.UIChief.SetSlider_Training(this.curZombie);

        // :: CalmDown
        int curCalmDown = this.curZombie.Get_CurCalmDown();
        int maxCalmDown = this.curZombie.Get_MaxCalmDown();
        this.UIChief.SetUI_CalmDown(curCalmDown, maxCalmDown);

        // :: Gold
        int curGold = this.minister.PLAYERSecretary.Gold_Current;
        this.UIChief.SetText_Gold(curGold);

        // :: Foods
        this.UIChief.UpdateButton_Foods(curGold);
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
        Debug.LogWarning("== Training Point로 성공 실패 판정");
        this.curZombie.Set_CompleteStatus();

        // :: Pack
        Pack_ReleaseZombie pack = this.Packing_ReleaseZombie();

        // :: Show
        this.UIChief.ShowField_NoticeReleaseZombie(true, pack);
    }
    private void Scenario_GoToGotcha()
    {
        this.UIChief.FadeDim(Enum.eFade.OUT, () =>
        {
            this.minister.SCENESecretary.LoadScene(Enum.eScene.GOTCHA);
        });
    }

    // : Packing
    private Pack_ReleaseZombie Packing_ReleaseZombie()
    {
        // :: Packing
        // >> Complete
        Enum.eCompleteStatus eComplete = this.curZombie
            .Get_CompleteStatus();
        // >> Name
        int nameID = this.curZombie.Get_ZombieNameID();
        string name = this.minister.DATASecretary.DictName[nameID].name;
        // >> Gold
        int gold = this.curZombie.Get_CompleteGold();
        // >> Description
        int descriptionID = this.curZombie
            .Get_DescriptionCompleteID(eComplete);
        string description = this.minister.DATASecretary
            .DictDescription_Complete[descriptionID].description;

        return new Pack_ReleaseZombie(
            name, gold, eComplete, description);
    }

    // :: Observer Pattern
    // >> Status
    private bool isEnd = false;
    public void UpdateSecond(System.DateTime time)
    {
        if (isEnd)
            return;

        this.Scenario_Update();
        this.Scenario_CheckRelease();
    }
    public void UpdateMinute(System.DateTime time)
    {

    }
}
