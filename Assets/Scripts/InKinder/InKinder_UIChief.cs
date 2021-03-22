using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InKinder_UIChief : UIChief
{
    // : Init
    // >> Assign
    [Header("Private")]
    [SerializeField]
    private Button BUTTON_NoticeNewZombie;
    [SerializeField]
    private Text TEXT_NoticeNewZombie;
    [SerializeField]
    private Slider SLIDER_Deadline;
    public override void Init()
    {
        this.FADEMachine = this.gameObject.AddComponent<FADEMachine>();
    }

    // : Add Button Listener
    public void AddButtonListener_NoticeNewZombie(System.Action action)
    {
        this.BUTTON_NoticeNewZombie.onClick
            .AddListener(() => { action(); });
    }

    // : Change
    public void ChangeSlider_Deadline(int value)
    {
        this.SLIDER_Deadline.value = value;
    }

    // : Set
    public void SetSlider_Deadline(int max)
    {
        this.SLIDER_Deadline.maxValue = max;
    }

    // : Show
    public void ShowButton_NoticeNewZombie(bool check, string text = "")
    {
        if (text != "")
            this.TEXT_NoticeNewZombie.text = text;

        this.BUTTON_NoticeNewZombie.gameObject.SetActive(check);
    }
}
