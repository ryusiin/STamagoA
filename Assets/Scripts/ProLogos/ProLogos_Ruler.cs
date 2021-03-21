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
    private void ButtonScenario_Previous()
    {
        Clerk.Warn("잠시 동안 버튼 클릭 안되게");
        this.UIChief.SlideStory_Previous();
        Clerk.Warn("Previous 및 Next 가능한 지를 확인");
    }
    private void ButtonScenario_Next()
    {
        Clerk.Warn("잠시 동안 버튼 클릭 안되게");
        this.UIChief.SlideStory_Next();
        Clerk.Warn("Previous 및 Next 가능한 지를 확인");
    }

    // : Start
    protected override void StartRuler()
    {
        Clerk.Warn("Previous 및 Next 가능한 지를 확인");
        Debug.LogWarning(":: Slide 자동 구현");

        // :: Fade
        this.UIChief.FadeDim(Enum.eFade.IN);
    }
}
