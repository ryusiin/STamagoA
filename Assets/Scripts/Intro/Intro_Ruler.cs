using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Intro_Ruler : Ruler
{
    // : Chief
    private Intro_UIChief UIChief;

    // : Init
    public override void Init()
    {
        // :: Chief
        this.UIChief = GameObject.FindObjectOfType<Intro_UIChief>();
        this.UIChief.Init();

        // :: Init Complete
        Dictator.Debug_Init(this.ToString());

        // :: Start Scenario
        this.ScenarioStart();
    }

    // : Scenario
    protected override void ScenarioStart()
    {
        this.UIChief.FadeIn_Dim(() => {
            this.ScenarioEnd();
        });
    }
    protected override void ScenarioEnd()
    {
        this.UIChief.FadeOut_Dim(() => {
            Dictator.LoadScene(Enum.eScene.TITLE);
        });
    }
}
