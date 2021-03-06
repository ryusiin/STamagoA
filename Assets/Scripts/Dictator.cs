using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

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

        // ::
        DontDestroyOnLoad(this.gameObject);

        // :: Init
        this.Init();
    }

    // : Status

    // : Init
    private void Init()
    {
        // :: Debug
        Debug_AppName();
        Debug_AppVersion();

        // :: Init Complete
        Debug_Init(this.ToString());

        // :: Load Scene
        LoadScene(Enum.eScene.INTRO);
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
        Debug.Log(log);
    }
    
}
