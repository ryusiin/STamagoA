using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ruler : MonoBehaviour
{
    public bool isTest = false;
    protected virtual void Awake()
    {
        if (isTest)
            this.Init();
        else
            Dictator.Debug_CheckDictator();
    }
    public abstract void Init();
    protected abstract void ScenarioStart();
    protected abstract void ScenarioEnd();
}
