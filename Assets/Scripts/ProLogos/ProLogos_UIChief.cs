using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProLogos_UIChief : UIChief
{
    [Header("Private")]
    [SerializeField]
    private Transform FIELD_Story;
    [SerializeField]
    private Button BUTTON_Previous;
    [SerializeField]
    private Button BUTTON_Next;

    // : Init
    // >> Machine
    private SLIDEMachine SLIDEMachine;
    // >> Status : Const
    const int GAP_FIELD_STORY = 1500;
    public override void Init()
    {
        this.FADEMachine = this.gameObject.AddComponent<FADEMachine>();
        this.SLIDEMachine = this.gameObject.AddComponent<SLIDEMachine>();
    }

    // : Add Button Scenario
    public void AddButtonScenario_Previous(System.Action action)
    {
        this.BUTTON_Previous.onClick.AddListener(() => { action(); });
    }
    public void AddButtonScenario_Next(System.Action action)
    {
        this.BUTTON_Next.onClick.AddListener(() => { action(); });
    }

    // : Slide
    public void SlideStory_Previous()
    {
        this.SLIDEMachine.SlidePrevious(
            this.FIELD_Story, GAP_FIELD_STORY);
    }
    public void SlideStory_Next()
    {
        this.SLIDEMachine.SlideNext(
            this.FIELD_Story, GAP_FIELD_STORY);
    }
}
