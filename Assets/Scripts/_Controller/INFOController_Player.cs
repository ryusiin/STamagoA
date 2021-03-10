using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;

public class INFOController_Player
{
    // : Constructor
    public INFOController_Player() { }

    // : Status
    private Info_Player infoPlayer;

    // : Init
    public void Init()
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
        if (this.infoPlayer.guid == "" || this.infoPlayer.guid == null)
            this.SetGUID();
        if (this.infoPlayer.nickname == "" || this.infoPlayer.nickname == null)
            this.SetNickname("Amy");
        if (this.infoPlayer.start_date == "" || this.infoPlayer.start_date == null)
            this.SetDate_Start(new DateTime(0));
        if (this.infoPlayer.last_date == "" || this.infoPlayer.last_date == null)
            this.SetDate_Last(new DateTime(0));

        return JsonConvert.SerializeObject(this.infoPlayer);
    }
    public void SetGUID()
    {
        this.infoPlayer.guid = Guid.NewGuid().ToString();
        this.Save();
    }
    public void SetNickname(string nickname)
    {
        this.infoPlayer.nickname = nickname;
        this.Save();
    }
    public System.Action Please_SetDate_Start;
    public void SetDate_Start(DateTime startDate)
    {
        // :: Null
        if (startDate == new DateTime(0))
        {
            this.Please_SetDate_Start();
            return;
        }

        this.infoPlayer.start_date = startDate.ToString();
        this.Save();
    }
    public System.Action Please_SetDate_Last;
    public void SetDate_Last(DateTime lastDate)
    {
        // :: Null
        if (lastDate == new DateTime(0))
        {
            this.Please_SetDate_Last();
            return;
        }

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
