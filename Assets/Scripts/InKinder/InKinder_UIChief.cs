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
    [SerializeField]
    private InKinder_UILeader_OX UILeader_OX;
    [SerializeField]
    private InKinder_UILeader_Training UILeader_Training;
    public override void Init()
    {
        // :: Use
        this.FADEMachine = this.gameObject.AddComponent<FADEMachine>();

        // :: Leader
        this.UILeader_OX.Init();
        this.UILeader_Training.Init();

        // :: UI
        this.InitUIPosition();
    }
    public void Init_FoodButtons(Dictionary<int, DATAFood> DictFood,
        System.Action<Enum.eFood> DelegateButton_Foods)
    {
        // :: Delegate
        this.UILeader_Food.DelegateButton_Foods = DelegateButton_Foods;

        // :: Init
        this.UILeader_Food.Init_FoodButtons(DictFood);
    }
    public void Init_OX(System.Action<int> DelegateEnd_OXGame)
    {
        this.UILeader_OX.DelegateEnd_OXGame = DelegateEnd_OXGame;
    }
    // >> Status : const
    private readonly Vector3 ADJUST_UI_POSITION = new Vector3(0, -960, 0);
    private void InitUIPosition()
    {
        // :: OX
        this.UILeader_OX.gameObject.SetActive(false);
        this.UILeader_OX.transform.localPosition = Vector3.zero
            + ADJUST_UI_POSITION;
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
        this.UILeader_Button.AddButtonListener_Food(action);
    }
    public void AddButtonListener_Training(System.Action action)
    {
        this.UILeader_Button.AddButtonListener_Training(action);
    }

    // : Can
    public void CanTouchButton_All(bool check)
    {
        this.UILeader_Button.CanTouchButton_All(check);
    }

    // : Get
    public bool GetIsActive_FieldFood()
    {
        return this.UILeader_Food.GetIsActive();
    }

    // : Set
    public void SetSlider_Deadline(int cur, int max)
    {
        this.SLIDER_Deadline.maxValue = max;
        this.SLIDER_Deadline.value = cur;
    }
    public void SetSlider_Training(CLASSZombie zombie)
    {
        this.UILeader_Training.SetSlider_Training(zombie);
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
            this.UILeader_Button.CanTouchButton(Enum.eButton.FOOD, true);
        }
        else
            this.CanTouchButton_All(true);
    }
    public void ShowField_OX(bool check, Dictionary<int, DATAOX> DictOX = null)
    {
        // :: Show
        this.UILeader_OX.gameObject.SetActive(check);

        // :: True
        if (check)
        {
            // >> Data
            this.UILeader_OX.Init_Status(DictOX);
            // >> UI
            this.UILeader_Button.CanTouchButton(Enum.eButton.TRAINING, true);
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
