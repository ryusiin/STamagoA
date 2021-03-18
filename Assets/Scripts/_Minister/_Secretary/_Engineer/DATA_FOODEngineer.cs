using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

public class DATA_FOODEngineer : Engineer
{
    // : Constructor
    public DATA_FOODEngineer() { this.Init(); }

    // : Init
    protected override void Init()
    {
        // :: Load
        this.LoadJSON_Zombie();

        // :: Complete
        Clerk.Log(Enum.eLog.INIT, this.ToString());
    }

    // : Load
    public Dictionary<Enum.eFood, DATAFood> DictFood { get; private set; }
    private void LoadJSON_Zombie()
    {
        string json = Resources.Load<TextAsset>("JSON/Data/data_food").text;
        this.DictFood = JsonConvert.DeserializeObject<DATAFood[]>(json)
            .ToDictionary(ele => (Enum.eFood)ele.id);
    }
}
