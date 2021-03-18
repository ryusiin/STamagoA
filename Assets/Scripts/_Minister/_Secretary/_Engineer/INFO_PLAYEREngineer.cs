using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;

public class INFO_PLAYEREngineer : Engineer
{
    // : Constructor
    public INFO_PLAYEREngineer() { this.Init(); }

    // : Status
    private Info_Player infoPlayer;

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
        this.infoPlayer = JsonConvert.DeserializeObject<Info_Player>(json);

    }

    // : Get
    private string GetPath()
    {
        return Application.persistentDataPath + NAME_FILE;
    }
    public DateTime GetTime_Last()
    {
        return DateTime.Parse(this.infoPlayer.last_date);
    }

    // : Load
    const string KEY_PREFS = "player_guid";
    const string NAME_FILE = "/info_player.json";
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
        // :: Use
        this.infoPlayer = new Info_Player();

        // :: Init
        this.SetGUID();
        this.SetNickname("No Name");
        DateTime timeCurrent = this.Minister.DATASecretary.GetTime_Current();
        this.SetDate_Start(timeCurrent);
        this.SetDate_Last(timeCurrent);

        // :: Save
        this.Save();

        // :: Callback
        return JsonConvert.SerializeObject(this.infoPlayer);
    }
    private void SetGUID()
    {
        this.infoPlayer.guid = Guid.NewGuid().ToString();
        this.Save();
    }
    public void SetNickname(string nickname)
    {
        this.infoPlayer.nickname = nickname;
        this.Save();
    }
    public void SetDate_Start(DateTime startDate)
    {
        this.infoPlayer.start_date = startDate.ToString();
        this.Save();
    }
    public void SetDate_Last(DateTime lastDate)
    {
        this.infoPlayer.last_date = lastDate.ToString();
        this.Save();
    }

    // : Save
    private void Save()
    {
        string json = JsonConvert.SerializeObject(this.infoPlayer);

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
