using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class INFOController_Zombie
{
    // : Constructor
    public INFOController_Zombie() { this.Init(); }

    // : Controller
    private DATAController_Zombie DATAController;

    // : Status
    private Info_Zombie infoZombie_Load;

    // : Init
    private void Init()
    {
        // :: Controller
        this.DATAController = new DATAController_Zombie();

        // :: Load Data
        string json = this.LoadFile();
        if (json == null)
            json = this.LoadPrefs();
        if (json == null)
            json = this.SetInit();

        // :: Set
        this.infoZombie_Load = JsonConvert.DeserializeObject<Info_Zombie>(json);
    }

    // : Get
    private string GetPath()
    {
        return Application.persistentDataPath + NAME_FILE;
    }
    public Class_Zombie GetZombie_Current()
    {
        Enum.eZombie eZombie = this.infoZombie_Load.type;
        Data_Zombie dataZombie = DATAController.DictZombie[eZombie];
        Class_Zombie curZombie = new Class_Zombie(dataZombie);
        curZombie.ChangeInfo(this.infoZombie_Load);

        return curZombie;
    }

    // : Load
    const string KEY_PREFS = "zombie_current";
    const string NAME_FILE = "/info_zombie_current.json";
    private string LoadFile()
    {
        // :: File
        string path = this.GetPath();
        bool checkFile = File.Exists(path);
        if (checkFile)
            return File.ReadAllText(path);

        return null;
    }
    private string LoadPrefs()
    {
        // :: Get
        string json = PlayerPrefs.GetString(KEY_PREFS);
        if (json.Length >= 5)
            return json;

        return null;
    }

    // : Set
    private string SetInit()
    {
        // :: Make
        Data_Zombie dataZombie = DATAController.DictZombie[Enum.eZombie.EMMA];
        Class_Zombie newZombie = new Class_Zombie(dataZombie);
        this.infoZombie_Load = newZombie.Info;

        // :: Save
        this.Save(this.infoZombie_Load);

        // :: Callback
        return JsonConvert.SerializeObject(this.infoZombie_Load);
    }

    // : Save
    public void Save(Info_Zombie info_Zombie)
    {
        string json = JsonConvert.SerializeObject(info_Zombie);

        this.SavePrefs(json);
        this.SaveFile(json);
    }
    private void SavePrefs(string json)
    {
        PlayerPrefs.SetString(KEY_PREFS, json);
    }
    private void SaveFile(string json)
    {
        File.WriteAllText(this.GetPath(), json);
    }
}
