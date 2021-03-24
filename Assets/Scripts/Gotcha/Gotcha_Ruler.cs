using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gotcha_Ruler : Ruler
{
    // : Init
    // >> Chief
    private Gotcha_UIChief UIChief;
    private Gotcha_GOChief GOChief;
    protected override void InitChief()
    {
        this.UIChief = GameObject.FindObjectOfType<Gotcha_UIChief>();
        this.UIChief.Init();
        this.GOChief = GameObject.FindObjectOfType<Gotcha_GOChief>();
        this.GOChief.Init();
    }
    protected override void InitStatus() { }
    protected override void InitButtons()
    {
        this.UIChief.AddButtonListener_Gotcha(this.ButtonScenario_Gotcha);
        this.UIChief.AddButtonListener_Return(this.ButtonScenario_Return);
    }

    // : Start
    protected override void StartRuler()
    {
        // :: Fade
        this.UIChief.FadeDim(Enum.eFade.IN);
    }

    // : Button Scenario
    // >> Status
    const int START_ZOMBIE = 1;
    const int END_ZOMBIE_PLUS = 4;
    private void ButtonScenario_Gotcha()
    {
        // :: Set
        this.UIChief.CanClickButton_Gotcha(false);

        // :: Get
        System.Random rand = new System.Random();
        int randZombie = rand.Next(START_ZOMBIE, END_ZOMBIE_PLUS);

        // :: Set
        this.Scenario_SetZombie(randZombie);

        // :: Animation
        this.GOChief.DoAnimation_Gotcha();
        this.Do_NextSeconds(() =>
        {
            this.UIChief.ShowUI_Name(true);
            this.UIChief.ShowButton_Return(true);
        }, 0.8f);
    }
    private void ButtonScenario_Return()
    {
        this.UIChief.FadeDim(Enum.eFade.OUT, () =>
        {
            this.minister.SCENESecretary.LoadScene(Enum.eScene.IN_KINDER);
        });
    }

    // : Scenario
    private void Scenario_SetZombie(int randZombie)
    {
        //:: Get
        CLASSZombie newZombie = this.minister.ZOMBIESecretary
            .CreateZombie(randZombie);

        // :: Change
        this.minister.ZOMBIESecretary.ChangeZombie_Current(newZombie);

        // :: Set
        CLASSZombie curZombie =
            this.minister.ZOMBIESecretary.Zombie_Current;
        this.GOChief.Set_ZombieModel(curZombie.Get_ModelType());
        int nameID = curZombie.Get_ZombieNameID();
        string name = this.minister.DATASecretary.DictName[nameID].name;
        this.UIChief.ShowUI_Name(false, name);
    }
}
