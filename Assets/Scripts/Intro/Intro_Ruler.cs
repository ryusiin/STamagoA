using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Ruler : Ruler
{
    // : Init
    private Intro_UIChief UIChief;
    protected override void InitChief()
    {
        this.UIChief = GameObject.FindObjectOfType<Intro_UIChief>();
        this.UIChief.Init();
    }
    protected override void InitStatus() { }
    protected override void InitButtons() { }

    // : Start
    protected override void StartRuler()
    {
        this.UIChief.FadeDim(Enum.eFade.IN,
            () => { this.UIChief.FadeDim(Enum.eFade.OUT,
                () => { this.minister
                    .SCENESecretary.LoadScene(Enum.eScene.TITLE); }); });
    }
}
