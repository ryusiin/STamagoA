using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_UIChief : UIChief
{
    // : Assign
    [Header("Private")]
    [SerializeField]
    private Text TEXT_TouchToStart;
    [SerializeField]
    private Button BUTTON_GoToInKinder;

    // : Init
    // >> Machine
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
}
