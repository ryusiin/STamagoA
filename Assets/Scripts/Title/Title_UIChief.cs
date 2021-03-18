using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Title_UIChief : UIChief
{
    // : Holder
    [SerializeField]
    private Text TEXT_TouchToStart;
    [SerializeField]
    private Image IMAGE_Dim;
    [SerializeField]
    private Button BUTTON_GoTo_InKinder;

    // : Controller
    private TEXTController TEXTController;

    // : Init
    public override void Init()
    {
        // :: Check
        this.Check_Assign(this.IMAGE_Dim,
            this.TEXT_TouchToStart);

        // :: Controller
        this.DIMController = new DIMController(IMAGE_Dim);
        this.TEXTController = new TEXTController();

        // :: Dim
        this.DIMController.On(true);

        // :: Init Complete
        Clerk.Log(Enum.eLog.INIT, this.ToString());
    }

    // : Add Button Listner
    public void AddButtonListner_GoTo_InKinder(System.Action action)
    {
        this.BUTTON_GoTo_InKinder.onClick.AddListener(() => { action(); });
    }

    // : Blink
    public void BlinkText_TouchToStart()
    {
        this.TEXTController.Blink(this.TEXT_TouchToStart, FADE_DURATION);
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
    public void FadeInText_TouchToStart(System.Action action)
    {
        this.TEXTController.Callback_FadeIn = action;
        this.TEXTController.FadeIn(this.TEXT_TouchToStart, FADE_DURATION);
    }
}
