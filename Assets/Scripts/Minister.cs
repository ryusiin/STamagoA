using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minister : MonoBehaviour
{
    // : Init
    // >> Secretary
    public APPSecretary APPSecretary { get; private set; }
    public SCENESecretary SCENESecretary { get; private set; }
    public void Init() {
        // :: Secretary
        this.APPSecretary = this.gameObject.AddComponent<APPSecretary>();
        this.APPSecretary.Init(this);
        this.SCENESecretary = this.gameObject.AddComponent<SCENESecretary>();
        this.SCENESecretary.Init(this);

        // :: Complete
        this.ScenarioStart();
    }

    // : Scenario
    private void ScenarioStart()
    {
        // :: Load
        this.SCENESecretary.LoadScene(Enum.eScene.INTRO);
    }
}
