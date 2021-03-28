using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InKinder_UILeader_ReleaseZombie : MonoBehaviour
{
    // : Set
    // >> Assign
    [SerializeField]
    private Text TEXT_Name;
    [SerializeField]
    private Text TEXT_Gold;
    [SerializeField]
    private Text TEXT_Description;
    [SerializeField]
    private GameObject FIELD_CompleteSuccess;
    [SerializeField]
    private GameObject FIELD_CompleteFail;
    [SerializeField]
    private Button BUTTON_Release;
    public void Set(Pack_ReleaseZombie pack)
    {
        // :: Init
        this.FIELD_CompleteSuccess.SetActive(false);
        this.FIELD_CompleteFail.SetActive(false);

        // :: Set
        this.TEXT_Name.text = pack.zombieName;
        this.TEXT_Gold.text = "+" + pack.earningGold;
        this.TEXT_Description.text = pack.completeDescription;

        if (pack.eCompleteStatus == Enum.eCompleteStatus.SUCCESS)
            this.FIELD_CompleteSuccess.SetActive(true);
        else
            this.FIELD_CompleteFail.SetActive(true);
    }

    // : Add Button Listener
    public void AddButtonListener_Release(System.Action action)
    {
        this.BUTTON_Release.onClick.AddListener(() => { action(); });
    }

    // : Do Animation
    // >> Status : Const
    const string TEXT_TRIG_DO = "TRIG_Do";
    public void DoAnimation()
    {
        Animator isAnimator = this.gameObject.GetComponent<Animator>();
        int hash_TRIG_Do = Animator.StringToHash(TEXT_TRIG_DO);
        isAnimator.SetTrigger(hash_TRIG_Do);
    }
}
