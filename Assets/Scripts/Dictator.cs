using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class Dictator : MonoBehaviour
{
    // : 0 Awake
    private void Awake()
    {
        // :: Check Overlap
        int hashThis = this.GetHashCode();
        Dictator dictatorFound = GameObject.FindObjectOfType<Dictator>();
        int hashFound = dictatorFound.GetHashCode();
        if (hashThis != hashFound)
            Object.Destroy(dictatorFound.gameObject);

        // :: Use Always
        DontDestroyOnLoad(this.gameObject);

        // :: Init
        this.Init();
    }

    // : Controller
    private INFOController_Player INFOController_Player;
    // : Manager
    private TIMEManager TIMEManager;

    // : Init
    private void Init()
    {
        // :: Debug
        Debug_AppName();
        Debug_AppVersion();

        // :: Manager
        this.TIMEManager = this.gameObject.AddComponent<TIMEManager>();
        this.TIMEManager.Callback_ReachedMinute = this.Scenario_ReachedMinute;
        this.TIMEManager.Init();

        // :: Controller
        this.INFOController_Player = new INFOController_Player();
        this.INFOController_Player.Please_SetDate_Start = this.Scenario_SetDate_Start;
        this.INFOController_Player.Please_SetDate_Last = this.Scenario_SetDate_Last;
        this.INFOController_Player.Init();

        // :: Init Complete
        Debug_Init(this.ToString());

        // :: Load Scene
        LoadScene(Enum.eScene.INTRO);

        // :: Scenario Start
        this.Scenario_Start();
    }

    // : Scenario
    private void Scenario_Start()
    {
        // : Check Gap
        int gapTime = this.GetTime_Gap();
        if (gapTime > 0)
            this.Scenario_Reward_Offline(gapTime);
    }
    private void Scenario_Reward_Offline(int gapTime)
    {
        Debug.Log(string.Format("Time gap is : <color=red>{0}</color>", gapTime));
        Debug.Log(string.Format("***** 여기서 오프라인 리워드 주기"));
        // :: 오프라인 리워드 주기

        // :: Reset Last Time
        this.Scenario_SetDate_Last();
    }
    private void Scenario_ReachedMinute(DateTime curTime)
    {
        this.INFOController_Player.SetDate_Last(curTime);

        Debug.Log(string.Format("<color=red>{0}</color>", curTime));
    }
    private void Scenario_SetDate_Start()
    {
        DateTime curTime = this.TIMEManager.GetCurTime();
        this.INFOController_Player.SetDate_Start(curTime);
    }
    private void Scenario_SetDate_Last()
    {
        DateTime curTime = this.TIMEManager.GetCurTime();
        this.INFOController_Player.SetDate_Last(curTime);
    }

    // : Load
    public static void LoadScene(Enum.eScene eScene)
    {
        // :: Clean
        DOTween.KillAll();

        // :: Do
        int sceneID = (int)eScene;
        AsyncOperation sync = SceneManager.LoadSceneAsync(sceneID);
        sync.completed += scene =>
        {
            if (scene.isDone)
                switch(eScene)
                {
                    case Enum.eScene.INTRO:
                        InitScene<Intro_Ruler>();
                        break;
                    case Enum.eScene.TITLE:
                        InitScene<Title_Ruler>();
                        break;
                    case Enum.eScene.IN_KINDER:
                        InitScene<InKinder_Ruler>();
                        break;
                }
        };
    }

    // : Get
    private int GetTime_Gap()
    {
        DateTime curTime = this.TIMEManager.GetCurTime();
        DateTime lastTime = this.INFOController_Player.GetTime_Last();

        Debug.Log(string.Format("Time Current is : <color=yellow>{0}</color>", curTime));
        Debug.Log(string.Format("Time Last is : <color=green>{0}</color>", lastTime));

        TimeSpan gapTime = curTime - lastTime;

        return (int)gapTime.TotalMinutes;
    }

    // : Init
    public static void InitScene<T>() where T : Ruler
    {
        var Ruler = GameObject.FindObjectOfType<T>();
        Ruler.Init();
    }

    // : Debug
    public static void Debug_AppName()
    {
        string log = string.Format(":: App Name : {0}", Application.productName);
        Debug.Log(log);
    }
    public static void Debug_AppVersion()
    {
        string log = string.Format(":: App Version : {0}", Application.version);
        Debug.Log(log);
    }
    public static void Debug_CheckAssign(string scriptName)
    {
        string log = string.Format(":: {0} has Null Object", scriptName);
        Debug.LogError(log);
    }
    public static void Debug_CheckDictator()
    {
        Dictator dictator = GameObject.FindObjectOfType<Dictator>();
        if (dictator == null)
            SceneManager.LoadScene((int)Enum.eScene.DICTATOR);
    }
    public static void Debug_Init(string scriptName)
    {
        string log = string.Format(":: {0} Init Complete", scriptName);
        //Debug.Log(log);
    }
    public static void Debug_Error(Enum.eError eError)
    {
        // :: 이 부분 에러 JSON 데이터 코드로 바꾸게 하기
        if (eError == Enum.eError.NETWORK_CONNECTION_FAILED)
            Debug.Log("에러!");
    }
    
}
