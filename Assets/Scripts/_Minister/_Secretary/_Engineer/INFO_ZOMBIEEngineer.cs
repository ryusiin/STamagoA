using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class INFO_ZOMBIEEngineer : Engineer
{
    // : Constructor
    public INFO_ZOMBIEEngineer() { this.Init(); }

    // : Status
    private Info_Zombie infoZombie_Load;

    // : Init
    protected override void Init()
    {
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
        DATAZombie dataZombie 
            = this.Minister.DATASecretary.GetData_Zombie(eZombie);
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
        Enum.eZombie baseZombie = (Enum.eZombie)1;
        DATAZombie dataZombie 
            = this.Minister.DATASecretary.GetData_Zombie(baseZombie);
        Class_Zombie newZombie = new Class_Zombie(dataZombie);

        // :: Init
        newZombie.Init(this.Minister.DATASecretary.GetTime_Current());

        // :: Set
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
