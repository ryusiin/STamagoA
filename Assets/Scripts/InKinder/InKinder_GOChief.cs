using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InKinder_GOChief : GOChief
{
    // : Init
    // >> Assign
    [SerializeField]
    private GOLeader_Zombie ZOMBIELeader;
    public override void Init()
    {
    }

    // : Set
    public void Set_ZombieModel(Enum.eZombie eZombie)
    {
        this.ZOMBIELeader.Select_ZombieModel(eZombie);
    }
}
