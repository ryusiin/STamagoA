using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gotcha_GOChief : GOChief
{
    // : Init
    // >> Animator
    const string TRIG_GOTCHA = "TRIG_Gotcha";
    private Animator COMPAnimator;
    private int hash_TRIGGotcha;
    // >> Assign
    [SerializeField]
    private GOLeader_Zombie ZOMBIELeader;
    public override void Init()
    {
        this.COMPAnimator = this.GetComponent<Animator>();
        this.hash_TRIGGotcha = Animator.StringToHash(TRIG_GOTCHA);
    }

    // : Do
    public void DoAnimation_Gotcha()
    {
        this.COMPAnimator.SetTrigger(this.hash_TRIGGotcha);
    }

    // : Set
    public void Set_ZombieModel(Enum.eZombie eZombie)
    {
        this.ZOMBIELeader.Select_ZombieModel(eZombie);
    }
}
