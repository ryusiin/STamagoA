using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Title_Ruler : Ruler
{
    // : Chief
    private Title_UIChief UIChief;

    // : Init
    public override void Init()
    {
        // :: Chief
        this.UIChief = GameObject.FindObjectOfType<Title_UIChief>();
        this.UIChief.Init();

        // :: Add Button Scenario
        this.AddButtonScenario_GoTo_InKinder();

        // :: Init Complete 
        Dictator.Debug_Init(this.ToString());

        // :: Start Scenario
        this.ScenarioStart();
    }

    // : Button Scenario
    private void AddButtonScenario_GoTo_InKinder()
    {
        this.UIChief.AddButtonListner_GoTo_InKinder(() =>
        {
            this.ScenarioEnd();
        });
    }

    // : Scenario
    protected override void ScenarioStart()
    {
        this.UIChief.FadeIn_Dim(() =>
        {
            this.UIChief.FadeInText_TouchToStart(() => {
                this.UIChief.BlinkText_TouchToStart();
            });
        });
    }
    protected override void ScenarioEnd()
    {
        this.UIChief.FadeOut_Dim(() =>
        {
            Dictator.LoadScene(Enum.eScene.IN_KINDER);
        });
    }
}
