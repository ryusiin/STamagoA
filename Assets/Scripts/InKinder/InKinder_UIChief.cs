using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InKinder_UIChief : UIChief
{
    // : Holder
    [SerializeField]
    private Image IMAGE_Dim;
    [Header("Button")]
    [SerializeField]
    private Button BUTTON_Training;
    [SerializeField]
    private Button BUTTON_Food;
    [SerializeField]
    private Button BUTTON_Clean;
    [SerializeField]
    private Button BUTTON_Factory;

    // : Init
    public override void Init()
    {
        // :: Null Check
        this.Check_Assign(
            this.IMAGE_Dim,
            this.BUTTON_Training,
            this.BUTTON_Food,
            this.BUTTON_Clean,
            this.BUTTON_Factory);

        // :: Dim
        this.DIMController = new DIMController(this.IMAGE_Dim);

        // :: Init Complete
        Dictator.Debug_Init(this.ToString());
    }

    // : Button Listener
    public void AddButtonListner_Training(System.Action action) 
    {
        this.BUTTON_Training.onClick.AddListener(() => { action(); });
    }
    public void AddButtonListner_Food(System.Action action)
    {
        this.BUTTON_Food.onClick.AddListener(() => { action(); });
    }
    public void AddButtonListner_Clean(System.Action action)
    {
        this.BUTTON_Clean.onClick.AddListener(() => { action(); });
    }
    public void AddButtonListner_Factory(System.Action action)
    {
        this.BUTTON_Factory.onClick.AddListener(() => { action(); });
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
