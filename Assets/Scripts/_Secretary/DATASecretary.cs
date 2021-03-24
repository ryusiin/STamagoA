using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DATASecretary : Secretary
{
    // : Init
    // >> Status : Dictionary
    public Dictionary<int, DATAName> DictName { get; private set; }
    public Dictionary<int, DATAZombie> DictZombie { get; private set; }
    public Dictionary<int, DATADescription_Zombie> 
        DictDescription_Zombie { get; private set; }
    public Dictionary<int, DATADescription_Complete>
        DictDescription_Complete { get; private set; }
    public override void Init(Minister Minister)
    {
        base.Init(Minister);

        // :: Use
        this.DictName = new Dictionary<int, DATAName>();
        this.DictZombie = new Dictionary<int, DATAZombie>();
        this.DictDescription_Zombie = 
            new Dictionary<int, DATADescription_Zombie>();
        this.DictDescription_Complete =
            new Dictionary<int, DATADescription_Complete>();

        // :: Load
        this.LoadData_All();
    }

    // Load
    // >> Status : Const
    const string PATH_NAME = "JSON/Data/data_name";
    const string PATH_ZOMBIE = "JSON/Data/data_zombie";
    const string PATH_DESCRIPTION_ZOMBIE 
        = "JSON/Data/data_description_zombie";
    const string PATH_DESCRIPTION_COMPLETE
        = "JSON/Data/data_description_complete";
    private void LoadData_All()
    {
        this.LoadData_Name();
        this.LoadData_Zombie();
        this.LoadData_Description_Zombie();
        this.LoadData_Description_Complete();
    }
    private void LoadData_Name()
    {
        string json = Resources
            .Load<TextAsset>(PATH_NAME).text;
        this.DictName = JsonConvert
            .DeserializeObject<DATAName[]>(json)
            .ToDictionary(ele => ele.id);
    }
    private void LoadData_Zombie()
    {
        string json = Resources
            .Load<TextAsset>(PATH_ZOMBIE).text;
        this.DictZombie = JsonConvert
            .DeserializeObject<DATAZombie[]>(json)
            .ToDictionary(ele => ele.id);
    }
    private void LoadData_Description_Zombie()
    {
        string json = Resources
            .Load<TextAsset>(PATH_DESCRIPTION_ZOMBIE).text;
        this.DictDescription_Zombie = JsonConvert
            .DeserializeObject<DATADescription_Zombie[]>(json)
            .ToDictionary(ele => ele.id);
    }
    private void LoadData_Description_Complete()
    {
        string json = Resources
            .Load<TextAsset>(PATH_DESCRIPTION_COMPLETE).text;
        this.DictDescription_Complete = JsonConvert
            .DeserializeObject<DATADescription_Complete[]>(json)
            .ToDictionary(ele => ele.id);
    }
}
