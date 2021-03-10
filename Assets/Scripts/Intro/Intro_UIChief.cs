using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro_UIChief : UIChief
{
    // : Holder
    [SerializeField]
    private Image IMAGE_Logo;
    [SerializeField]
    private Image IMAGE_Dim;

    // : Init
    public override void Init()
    {
        // :: Check
        this.Check_Assign(this.IMAGE_Logo,
            this.IMAGE_Dim);

        // :: Controller
        this.DIMController = new DIMController(IMAGE_Dim);

        // :: Dim
        this.DIMController.On(true);

        // :: Init Complete
        Dictator.Debug_Init(this.ToString());
    }

    // : Fade
    const float FADE_DURATION = 1.5f;
    public void FadeIn_Dim(System.Action action)
    {
        this.DIMController.Callback_FadeIn = action;
        this.DIMController.FadeIn(FADE_DURATION);
    }
    public void FadeOut_Dim(System.Action action)
    {
        this.DIMController.Callback_FadeOut = action;
        this.DIMController.FadeOut(FADE_DURATION);
    }
}
