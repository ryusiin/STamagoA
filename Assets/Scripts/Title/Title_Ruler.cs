using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Ruler : Ruler
{
    // : Init
    // >> Chief
    private Title_UIChief UIChief;
    protected override void InitChief()
    {
        // :: Chief
        this.UIChief = GameObject.FindObjectOfType<Title_UIChief>();
        this.UIChief.Init();
    }
    protected override void InitStatus() { }
    protected override void InitButtons()
    {
        this.UIChief.AddButtonListener_GoToInKinder(
            this.ButtonScenario_GoToInKinder);
    }

    // : Start
    protected override void StartRuler()
    {
        this.UIChief.BlinkText_TouchToStart();

        // :: Fade
        this.UIChief.FadeDim(Enum.eFade.IN);
    }

    // : Button Scenario
    private void ButtonScenario_GoToInKinder()
    {
        this.UIChief.FadeDim(Enum.eFade.OUT, this.Scenario_GoToInKinder);
    }

    // : Scenario
    private void Scenario_GoToInKinder()
    {
        bool isFirst = this.minister.APPSecretary.Get_IsFirstStart();
        if (isFirst)
            this.minister.SCENESecretary.LoadScene(Enum.eScene.PRO_LOGOS);
        else
            this.minister.SCENESecretary.LoadScene(Enum.eScene.IN_KINDER);
    }
}
