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
    [Header("Leader")]
    [SerializeField]
    private InKinder_UILeader_CalmDown UILeader_CalmDown;
    [SerializeField]
    private InKinder_UILeader_NewZombie UILeader_NewZombie;
    [SerializeField]
    private InKinder_UILeader_ReleaseZombie UILeader_ReleaseZombie;
    [SerializeField]
    private InKinder_UILeader_Food UILeader_Food;
    [SerializeField]
    private InKinder_UILeader_Button UILeader_Button;
    public override void Init()
    {
        // :: Use
        this.FADEMachine = this.gameObject.AddComponent<FADEMachine>();
    }
    public void Init_FoodButtons(Dictionary<int, DATAFood> DictFood,
        System.Action<Enum.eFood> DelegateButton_Foods)
    {
        // :: Delegate
        this.UILeader_Food.DelegateButton_Foods = DelegateButton_Foods;

        // :: Init
        this.UILeader_Food.Init_FoodButtons(DictFood);
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
    public void AddButtonListener_Food(System.Action action)
    {
        this.UILeader_Button.BUTTON_Food.onClick
            .AddListener(() => { action(); });
    }

    // : Can
    public void CanTouchButton_All(bool check)
    {
        this.UILeader_Button.BUTTON_Food.interactable = check;
        this.UILeader_Button.BUTTON_Training.interactable = check;
        this.UILeader_Button.BUTTON_Clean.interactable = check;
        this.UILeader_Button.BUTTON_Factory.interactable = check;
    }
    public void CanTouchButton_Food(bool check)
    {
        this.UILeader_Button.BUTTON_Food.interactable = check;
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

    // : Get
    public bool GetIsActive_FieldFood()
    {
        return this.UILeader_Food.GetIsActive();
    }

    // : Show
    public void ShowField_NoticeNewZombie(bool check, Pack_NewZombie pack = null)
    {
        if (pack != null)
            this.UILeader_NewZombie.Set(pack);

        this.UILeader_NewZombie.gameObject.SetActive(check);
    }
    public void ShowField_NoticeReleaseZombie(bool check, 
        Pack_ReleaseZombie pack = null)
    {
        if (pack != null)
            this.UILeader_ReleaseZombie.Set(pack);

        if (check)
            this.UILeader_ReleaseZombie.DoAnimation();
    }
    public void ShowField_Food(bool check)
    {
        // :: Show
        this.UILeader_Food.gameObject.SetActive(check);

        // :: Button
        if (check)
        {
            this.CanTouchButton_All(false);
            this.CanTouchButton_Food(true);
        }
        else
            this.CanTouchButton_All(true);
    }

    // :: Update
    public void UpdateButton_Foods(int currentGold)
    {
        this.UILeader_Food.UpdateButton_Foods(currentGold);
    }
}
