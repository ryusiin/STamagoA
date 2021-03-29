using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOLeader_Zombie : MonoBehaviour
{
    // : Init
    // >> Status : Const
    const string TEXT_TRIG_EAT = "TRIG_Eat";
    const string TEXT_BOOL_CRAZY = "BOOL_Crazy";
    // >> Status : Animation
    private Animator isAnimator;
    private int hash_TRIGEat;
    private int hash_BOOLCrazy;
    public void Init()
    {
        this.isAnimator = this.GetComponent<Animator>();
        this.hash_BOOLCrazy = Animator.StringToHash(TEXT_BOOL_CRAZY);
        this.hash_TRIGEat = Animator.StringToHash(TEXT_TRIG_EAT);

        // :: GO
        this.InitGOPosition();
    }
    private void InitGOPosition()
    {
        this.ALERTCanvas.SetActive(false);
    }

    // : Hide
    // >> Status : Const
    const string EXCEPT_CHILD = "Root";
    private void Hide_ZombieModel_All()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.ToString().Contains(EXCEPT_CHILD))
                continue;

            child.gameObject.SetActive(false);
        }
    }

    // : Blink
    // >> Assign
    public GameObject ALERTCanvas;
    public void Blink_Alert()
    {
        this.StartCoroutine(this.Blink_Alert_Impl());
    }
    private IEnumerator Blink_Alert_Impl()
    {
        this.ALERTCanvas.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        this.ALERTCanvas.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        this.ALERTCanvas.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        this.ALERTCanvas.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        this.ALERTCanvas.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        this.ALERTCanvas.SetActive(false);
    }

    // : Do
    public void DoAnimation(Enum.eAnimation eAnimation)
    {
        switch(eAnimation)
        {
            case Enum.eAnimation.EAT:
                isAnimator.SetTrigger(hash_TRIGEat);
                break;
            case Enum.eAnimation.CRAZY:
                isAnimator.SetBool(hash_BOOLCrazy, true);
                break;
            case Enum.eAnimation.IDLE:
                isAnimator.SetBool(hash_BOOLCrazy, false);
                break;
        }
    }

    // : Receive
    public System.Action Callback_EndAnimation;
    public void Receive_EndAnimation()
    {
        this.Callback_EndAnimation();
    }
    public System.Action Callback_EndEat;
    public void Receive_EndEat()
    {
        this.Callback_EndEat();
    }

    // : Select
    public void Select_ZombieModel(Enum.eZombie eZombie)
    {
        this.Hide_ZombieModel_All();
        this.Show_ZombieModel(eZombie);
    }

    // : Show
    // >> Assign
    [SerializeField]
    private GameObject ZOMBIE_EMMA;
    [SerializeField]
    private GameObject ZOMBIE_JEONG;
    [SerializeField]
    private GameObject ZOMBIE_ING_WEN;
    private void Show_ZombieModel(Enum.eZombie eZombie)
    {
        switch(eZombie)
        {
            case Enum.eZombie.EMMA:
                this.ZOMBIE_EMMA.SetActive(true);
                break;
            case Enum.eZombie.JEONG:
                this.ZOMBIE_JEONG.SetActive(true);
                break;
            case Enum.eZombie.ING_WEN:
                this.ZOMBIE_ING_WEN.SetActive(true);
                break;

        }
    }
}
