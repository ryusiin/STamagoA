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
    [Header("Slider")]
    [SerializeField]
    private Slider SLIDER_Training;
    [SerializeField]
    private Slider SLIDER_Deadline;

    // :: Leader
    private InKinder_UILeader_CalmDown UILeader_CalmDown;

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

        // :: Controller
        this.DIMController = new DIMController(this.IMAGE_Dim);

        // :: Leader
        this.UILeader_CalmDown = GameObject.FindObjectOfType<InKinder_UILeader_CalmDown>();
        this.UILeader_CalmDown.Init();

        // :: Dim
        this.DIMController.On(true);

        // :: Init Complete
        Clerk.Log(Enum.eLog.INIT, this.ToString());
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

    // : Can
    public void CanClickButton_All(bool check)
    {
        this.BUTTON_Food.interactable = check;
        this.BUTTON_Training.interactable = check;
        this.BUTTON_Clean.interactable = check;
        this.BUTTON_Factory.interactable = check;
    }

    // : Set
    public void SetStatus_CalmDown(float percent)
    {
        this.UILeader_CalmDown.SetStatus(percent);
    }
    public void SetStatus_Trainig(float percent)
    {
        Debug.Log(")))" + percent);
        this.SLIDER_Training.value = percent;
    }
    public void SetStatus_Deadline(float percent)
    {
        this.SLIDER_Deadline.value = percent;
    }

    // : Fade
    const float FADE_DURATION = 3f;
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
