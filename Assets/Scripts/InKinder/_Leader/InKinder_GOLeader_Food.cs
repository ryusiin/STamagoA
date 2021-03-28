using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InKinder_GOLeader_Food : MonoBehaviour
{
    // : Show
    // >> Assign
    public GameObject FOOD_1;
    public GameObject FOOD_2;
    public GameObject FOOD_3;
    public void ShowFood(Enum.eFood eFood)
    {
        this.HideFood_All();
        switch(eFood)
        {
            case Enum.eFood.RAW_MEAT:
                this.FOOD_1.SetActive(true);
                break;
            case Enum.eFood.CHEESE:
                this.FOOD_2.SetActive(true);
                break;
            case Enum.eFood.DONUT:
                this.FOOD_3.SetActive(true);
                break;
        }
    }

    // : Hide
    public void HideFood_All()
    {
        foreach(Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
