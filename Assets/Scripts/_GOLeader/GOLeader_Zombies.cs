using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOLeader_Zombies : Leader
{
    // : Assign
    [Header("Character")]
    [SerializeField]
    private GameObject ZOMBIE_Emma;

    // : Init
    public override void Init()
    {
        // :: Init Complete
        Dictator.Debug_Init(this.ToString());
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
