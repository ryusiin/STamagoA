using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InKinder_UILeader_Food : MonoBehaviour
{
    // : Init
    public System.Action<Enum.eFood> DelegateButton_Foods;
    private Dictionary<int, DATAFood> dictFood;
    public void Init_FoodButtons(Dictionary<int, DATAFood> DictFood)
    {
        foreach (Transform child in this.transform)
        {
            // :: Get
            InKinder_PF_Food food = 
                child.GetComponent<InKinder_PF_Food>();

            // :: Set
            this.dictFood = DictFood;
            
            // :: Init
            food.Init(this.dictFood);
            child.GetComponent<Button>()
                .onClick.AddListener(() => {
                    this.DelegateButton_Foods(food.eFood); });
        }
    }

    // : Update
    public void UpdateButton_Foods(int currentGold)
    {
        foreach(Transform child in this.transform)
        {
            // :: Get
            InKinder_PF_Food food = child.GetComponent<InKinder_PF_Food>();
            DATAFood foodData = this.dictFood[(int)food.eFood];
            Button foodButton = child.GetComponent<Button>();

            // :: Set
            if (currentGold < foodData.price)
                foodButton.interactable = false;
            else
                foodButton.interactable = true;
        }
    }

    // : Get
    public bool GetIsActive()
    {
        return this.gameObject.activeSelf;
    }
}
