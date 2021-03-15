using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOLeader_Zombies : Leader
{
    // : Assign
    [Header("Character")]
    [SerializeField]
    private GameObject ZOMBIE_Emma;

    // : Animator
    private Animator COMP_Animator;
    // >> Animation Hash
    const string TRIGGER_EAT = "TRIGGER_Eat";
    private int hash_TRIGGER_Eat;

    // : Init
    public override void Init()
    {
        // :: Component
        this.COMP_Animator = this.GetComponent<Animator>();
        this.hash_TRIGGER_Eat = Animator.StringToHash(TRIGGER_EAT);

        // :: Init Complete
        Dictator.Debug_Init(this.ToString());
    }

    // : Play
    public void PlayAnimation(Enum.eAnimation eAnimation)
    {
        switch(eAnimation)
        {
            case Enum.eAnimation.EAT:
                this.COMP_Animator.SetTrigger(this.hash_TRIGGER_Eat);
                break;
        }
    }

    // : Receive
    public void Receive_EndAnimation()
    {
        Debug.Log("Eat End");
    }

    // : Show
    public void ShowZombie(Enum.eZombie eZombie)
    {
        // : Hide
        this.HideZombie_All();

        // : Show
        if (eZombie == Enum.eZombie.EMMA)
            this.ZOMBIE_Emma.SetActive(true);
    }

    // : Hide
    private void HideZombie_All()
    {
        this.ZOMBIE_Emma.SetActive(false);
    }
}
