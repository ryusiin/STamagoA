using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

public class DATA_ZOMBIEEngineer : Engineer
{
    // : Constructor
    public DATA_ZOMBIEEngineer() { this.Init(); }

    // : Init
    protected override void Init() {
        // :: Load
        this.LoadJSON_Zombie();

        // :: Complete
        Clerk.Log(Enum.eLog.INIT, this.ToString());
    }

    // : Load
    public Dictionary<Enum.eZombie, DATAZombie> DictZombie { get; private set; }
    private void LoadJSON_Zombie()
    {
        string json = Resources.Load<TextAsset>("JSON/Data/data_zombie").text;
        this.DictZombie = JsonConvert.DeserializeObject<DATAZombie[]>(json)
            .ToDictionary(ele => (Enum.eZombie)ele.id);
    }
}
