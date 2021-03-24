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
    private Text TEXT_Gold;
    [SerializeField]
    private Slider SLIDER_Deadline;
    [SerializeField]
    private InKinder_UILeader_CalmDown UILeader_CalmDown;
    [SerializeField]
    private InKinder_UILeader_NewZombie UILeader_NewZombie;
    [SerializeField]
    private InKinder_UILeader_ReleaseZombie UILeader_ReleaseZombie;
    public override void Init()
    {
        // :: Use
        this.FADEMachine = this.gameObject.AddComponent<FADEMachine>();
    }

    // : Add Button Listener
    public void AddButtonListener_NoticeNewZombie(System.Action action)
    {
        this.UILeader_NewZombie.GetComponent<Button>().onClick
            .AddListener(() => { action(); });
    }
    public void AddButtonListener_Release(System.Action action)
    {
        this.UILeader_ReleaseZombie.AddButtonListener_Release(action);
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
    public void ShowButton_NoticeNewZombie(bool check, Pack_NewZombie pack = null)
    {
        if (pack != null)
            this.UILeader_NewZombie.Set(pack);

        this.UILeader_NewZombie.gameObject.SetActive(check);
    }
    public void ShowPack_NoticeReleaseZombie(bool check, 
        Pack_ReleaseZombie pack = null)
    {
        if (pack != null)
            this.UILeader_ReleaseZombie.Set(pack);

        if (check)
            this.UILeader_ReleaseZombie.DoAnimation();
    }
}
