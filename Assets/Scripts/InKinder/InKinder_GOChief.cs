using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InKinder_GOChief : Chief
{
    // : Assign
    [Header("Character")]
    [SerializeField]
    private GOLeader_Zombies GOLeader_Zombies;
    [Header("Food")]
    [SerializeField]
    private GameObject FOOD_1;

    // : Status
    private GameObject FOOD_Current;

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

    // : Show
    public void ShowFood(Enum.eFood eFood)
    {
        // :: Set
        if (eFood == Enum.eFood.BASIC_MEAT)
            this.FOOD_Current = this.FOOD_1;

        // :: Show
        if(this.FOOD_Current.activeSelf == false)
            this.FOOD_Current.SetActive(true);
    }
    // : Hide
    public void HideFood()
    {
        if(this.FOOD_Current.activeSelf == true)
            this.FOOD_Current.SetActive(false);
    }
}
