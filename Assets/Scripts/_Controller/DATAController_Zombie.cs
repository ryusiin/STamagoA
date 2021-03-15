using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

public class DATAController_Zombie
{
    // : Constructor
    public DATAController_Zombie() { this.Init(); }

    // : Init
    public void Init() {
        this.LoadJSON_All();
    }

    // : Load
    private void LoadJSON_All()
    {
        this.LoadJSON_Zombie();
    }
    public Dictionary<Enum.eZombie, Data_Zombie> DictZombie { get; private set; }
    private void LoadJSON_Zombie()
    {
        string json = Resources.Load<TextAsset>("JSON/Data/data_zombie").text;
        this.DictZombie = JsonConvert.DeserializeObject<Data_Zombie[]>(json)
            .ToDictionary(ele => (Enum.eZombie)ele.id);
    }
}
