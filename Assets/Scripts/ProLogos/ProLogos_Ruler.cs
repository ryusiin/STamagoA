using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProLogos_Ruler : Ruler
{
    // : Init
    // >> Chief
    private ProLogos_UIChief UIChief;
    protected override void InitChief()
    {
        this.UIChief = GameObject.FindObjectOfType<ProLogos_UIChief>();
        this.UIChief.Init();
    }
    protected override void InitStatus() { }
    protected override void InitButtons()
    {
        this.UIChief.AddButtonScenario_Previous(
            this.ButtonScenario_Previous);
        this.UIChief.AddButtonScenario_Next(
            this.ButtonScenario_Next);
    }

    // : Button Scenario
    // >> Status : Const
    const float BUTTON_WAIT_TIME = 0.3f;
    private void ButtonScenario_Previous()
    {
        this.UIChief.CanButton_All(false);
        this.UIChief.SlideStory_Previous();
        this.Do_NextSeconds(this.UIChief.UpdateButtons, 
            BUTTON_WAIT_TIME);
    }
    private void ButtonScenario_Next()
    {
        if (this.UIChief.Get_IsLastStorySlide())
            this.Scenario_GoToInKinder();
        else
        {
            this.UIChief.CanButton_All(false);
            this.UIChief.SlideStory_Next();
            this.Do_NextSeconds(this.UIChief.UpdateButtons,
                BUTTON_WAIT_TIME);
        }
    }

    // : Scenario
    public void Scenario_GoToInKinder()
    {
        this.UIChief.FadeDim(Enum.eFade.OUT, () => {
            this.minister.SCENESecretary
            .LoadScene(Enum.eScene.IN_KINDER);
        });
    }

    // : Start
    protected override void StartRuler()
    {
        this.UIChief.UpdateButtons();
        Debug.LogWarning("나중에 Slide 자동 구현 고려");

        // :: Fade
        this.UIChief.FadeDim(Enum.eFade.IN);
    }
}
