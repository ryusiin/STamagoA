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
    private Button BUTTON_NoticeReleaseZombie;
    [SerializeField]
    private Text TEXT_NoticeNewZombie;
    [SerializeField]
    private Text TEXT_Gold;
    [SerializeField]
    private Slider SLIDER_Deadline;
    [SerializeField]
    private InKinder_UILeader_CalmDown UILeader_CalmDown;
    [SerializeField]
    // >> Leader
    private InKinder_UILeader_NoticeReleaseZombie 
        NOTICELeader_ReleaseZombie;
    public override void Init()
    {
        // :: Use
        this.FADEMachine = this.gameObject.AddComponent<FADEMachine>();
        this.NOTICELeader_ReleaseZombie =
            this.BUTTON_NoticeReleaseZombie.gameObject
            .GetComponent<InKinder_UILeader_NoticeReleaseZombie>();
    }

    // : Add Button Listener
    public void AddButtonListener_NoticeNewZombie(System.Action action)
    {
        this.BUTTON_NoticeNewZombie.onClick
            .AddListener(() => { action(); });
    }
    public void AddButtonListener_NoticeReleaseZombie(
        System.Action action)
    {
        this.BUTTON_NoticeReleaseZombie.onClick
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
    public void SetUI_CalmDown(int cur, int max)
    {
        this.UILeader_CalmDown.Set(cur, max);
    }
    public void SetText_Gold(int gold)
    {
        string goldText = string.Format("{0:#,0}", gold);
        this.TEXT_Gold.text = goldText;
    }

    // : Show
    public void ShowButton_NoticeNewZombie(bool check, string text = "")
    {
        if (text != "")
            this.TEXT_NoticeNewZombie.text = text;

        this.BUTTON_NoticeNewZombie.gameObject.SetActive(check);
    }
    public void ShowPack_NoticeReleaseZombie(bool check, 
        Pack_ReleaseZombie pack = null)
    {
        if(pack != null)
            this.NOTICELeader_ReleaseZombie.Set(pack);

        this.NOTICELeader_ReleaseZombie.gameObject.SetActive(check);
    }
}
