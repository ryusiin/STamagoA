using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictator : MonoBehaviour
{
    // : Save
    public static Dictionary<int, string> dictLogs;

    // : 0 Awake
    private void Awake()
    {
        // :: Check
        this.CheckOverlap();

        // :: Don't Destroy
        DontDestroyOnLoad(this.gameObject);

        // :: Init
        this.Init();
    }

    // : Check
    private void CheckOverlap()
    {
        int hashThis = this.GetHashCode();
        Dictator dictatorFound = GameObject.FindObjectOfType<Dictator>();
        int hashFound = dictatorFound.GetHashCode();
        if (hashThis != hashFound)
            Object.Destroy(dictatorFound.gameObject);
    }

    // : Minister
    private static Minister Minister;

    // : Init
    private void Init()
    {
        // :: Use
        dictLogs = new Dictionary<int, string>();

        // :: Log
        Clerk.AppStatus();

        // :: Minister
        Minister = this.gameObject.AddComponent<Minister>();
        Minister.Init();

        // :: Complete
        Clerk.Log(Enum.eLog.INIT, this.ToString());

        // :: Load
        Minister.LoadScene(Enum.eScene.INTRO);
    }

    // : Censor
    public static void Censor()
    {
        // :: Find
        Dictator dictator = GameObject.FindObjectOfType<Dictator>();

        // :: Load Dictator
        if (dictator == null)
            Loader.LoadDictator();
    }
}
