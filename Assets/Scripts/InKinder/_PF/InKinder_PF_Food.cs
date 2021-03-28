using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InKinder_PF_Food : MonoBehaviour
{
    // : Init
    // >> Assign
    public Enum.eFood eFood;
    [SerializeField]
    private Image IMAGE_Food;
    [SerializeField]
    private Text TEXT_Price;
    // >> Status : Const
    const string PATH_RESOURCES = "Texture/Item/Food/";
    // >> Receive
    private Dictionary<int, DATAFood> dictFood;
    public void Init(Dictionary<int, DATAFood> DictFood)
    {
        // :: Get
        this.dictFood = DictFood;

        // :: Set
        DATAFood food = this.dictFood[(int)eFood];
        this.IMAGE_Food.sprite = 
            Resources.Load<Sprite>(PATH_RESOURCES + food.sprite_name);
        this.TEXT_Price.text = food.price.ToString();
    }
}
