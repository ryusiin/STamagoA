using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InKinder_GOChief : Chief
{
    // : Assign
    [Header("Character")]
    [SerializeField]
    private GOLeader_Zombies GOLeader_Zombies;

    // : Init
    public override void Init()
    {
        // :: Init Complete
        Dictator.Debug_Init(this.ToString());
    }

    // : Set
    public void SetZombie(Enum.eZombie eZombie)
    {
        this.GOLeader_Zombies.ShowZombie(eZombie);
    }
}
