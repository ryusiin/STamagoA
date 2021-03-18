using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ruler : MonoBehaviour
{
    // : 0 Awake
    public bool isTest = false;
    protected virtual void Awake()
    {
        if (isTest)
            this.Init();
        else
            Dictator.Censor();
    }

    // : Minister
    protected Minister Minister;
    public void InitMinister(Minister Minister)
    {
        this.Minister = Minister;
    }

    // : Init
    public abstract void Init();

    // : Scenario
    protected abstract void ScenarioStart();
    protected abstract void ScenarioEnd();
}
