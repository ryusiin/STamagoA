using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOLeader_Zombies : Leader, IAnimation
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

    // :: Observe
    private List<IObserver_Animation> listObservers_Animation;

    // : Init
    public override void Init()
    {
        // :: Component
        this.COMP_Animator = this.GetComponent<Animator>();
        this.hash_TRIGGER_Eat = Animator.StringToHash(TRIGGER_EAT);

        // :: Observe
        this.listObservers_Animation = new List<IObserver_Animation>();

        // :: Init Complete
        Clerk.Log(Enum.eLog.INIT, this.ToString());
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
        this.NotifyObservers_EndAnimation();
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

    // :: Observer Pattern
    public void RegisterObserver(IObserver_Animation observer)
    {
        if(!this.listObservers_Animation.Contains(observer))
            this.listObservers_Animation.Add(observer);
    }
    public void RemoveObserver(IObserver_Animation observer)
    {
        if (this.listObservers_Animation.Contains(observer))
            this.listObservers_Animation.Remove(observer);
    }
    public void NotifyObservers_EndAnimation()
    {
        foreach(var observer in listObservers_Animation)
            observer.EndAnimation();
    }
}
