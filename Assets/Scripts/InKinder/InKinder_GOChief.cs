using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InKinder_GOChief : GOChief
{
    // : Init
    // >> Assign
    [Header("Leader")]
    [SerializeField]
    private GOLeader_Zombie ZOMBIELeader;
    [SerializeField]
    private InKinder_GOLeader_Food FOODLeader;
    public override void Init()
    {
        this.ZOMBIELeader.Init();
    }

    // : Blink
    public void Blink_Alert()
    {
        this.ZOMBIELeader.Blink_Alert();
    }

    // : Do
    public void DoAnimation_Zombie(Enum.eAnimation eAnimation)
    {
        this.ZOMBIELeader.DoAnimation(eAnimation);
    }

    // : Hide
    public void Hide_Food()
    {
        this.FOODLeader.HideFood_All();
    }

    // : Set
    public void Set_ZombieModel(Enum.eZombie eZombie)
    {
        this.ZOMBIELeader.Select_ZombieModel(eZombie);
    }
    public void Set_EndAnimation(System.Action action)
    {
        this.ZOMBIELeader.Callback_EndAnimation = action;
    }
    public void Set_EndEat(System.Action action)
    {
        this.ZOMBIELeader.Callback_EndEat = action;
    }

    // : Show
    public void Show_Food(Enum.eFood eFood)
    {
        this.FOODLeader.ShowFood(eFood);
    }
}
