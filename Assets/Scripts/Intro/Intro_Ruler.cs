using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Ruler : MonoBehaviour
{
    // : 0 Awake
    private void Awake()
    {
        Dictator.Debug_CheckDictator();
    }

    // : Chief
    private Intro_UIChief UIChief;

    // : Init
    public void Init()
    {
        // :: Chief
        this.UIChief = GameObject.FindObjectOfType<Intro_UIChief>();
        this.UIChief.Init();

        // :: Init Complete
        Dictator.Debug_Init(this.ToString());

        // :: Start Scenario
        this.ScenarioStart();
    }

    // : Scenario
    private void ScenarioStart()
    {
        // :: 딤 만들어서 페이드 인
        // :: 끝나면 페이드 아웃
    }
}
