using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_UIChief : Chief
{
    // : Assign
    [SerializeField]
    private Image IMAGE_Dim;
    [SerializeField]
    private Text TEXT_TouchToStart;
    [SerializeField]
    private Button BUTTON_GoToInKinder;

    // : Init
    // >> Machine
    private FADEMachine FADEMachine;
    private BLINKMachine BLINKMachine;
    public override void Init()
    {
        this.FADEMachine = this.gameObject.AddComponent<FADEMachine>();
        this.BLINKMachine = this.gameObject.AddComponent<BLINKMachine>();
    }

    // : Add Button Listener
    public void AddButtonListener_GoToInKinder(System.Action action)
    {
        this.BUTTON_GoToInKinder.onClick.AddListener(() => { action(); });
    }

    // : Blink
    private Coroutine Coroutine_BlinkText_TouchToStart;
    public void BlinkText_TouchToStart()
    {
        this.Coroutine_BlinkText_TouchToStart =
            this.BLINKMachine.Blink(this.TEXT_TouchToStart);
    }
    public void StopBlinkText_TouchToStart()
    {
        if (this.Coroutine_BlinkText_TouchToStart != null)
            this.StopCoroutine(this.Coroutine_BlinkText_TouchToStart);
    }

    // : Fade
    public void FadeDim(Enum.eFade eFade, System.Action action = null)
    {
        if (eFade == Enum.eFade.IN)
            this.FADEMachine.FadeIn(this.IMAGE_Dim, action);
        else if (eFade == Enum.eFade.OUT)
            this.FADEMachine.FadeOut(this.IMAGE_Dim, action);
    }
}
