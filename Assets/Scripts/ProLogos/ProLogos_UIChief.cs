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
    [SerializeField]
    private Text TEXT_Next;

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

    // : Update
    // >> Status : Const
    const string WORD_NEXT = "NEXT";
    const string WORD_GO_TO_IN_KINDER = "START";
    public void UpdateButtons()
    {
        // :: Get
        int curSlide = this.Get_CurrentStorySlideNumber();

        // :: Set
        this.TEXT_Next.text = WORD_NEXT;

        // :: Check
        this.CanButton_All(true);
        if (curSlide <= 1)
        {
            this.BUTTON_Previous.interactable = false;
        }
        else if (this.Get_IsLastStorySlide())
            this.TEXT_Next.text = WORD_GO_TO_IN_KINDER;
    }

    // : Can
    public void CanButton_All(bool check)
    {
        this.BUTTON_Previous.interactable = check;
        this.BUTTON_Next.interactable = check;
    }

    // : Get
    private int Get_CurrentStorySlideNumber()
    {
        return this.SLIDEMachine.Get_CurrentSlideNumber(
            this.FIELD_Story, GAP_FIELD_STORY);
    }
    public bool Get_IsLastStorySlide()
    {
        int curSlide = this.Get_CurrentStorySlideNumber();
        return curSlide >= this.FIELD_Story.childCount;
    }
}
