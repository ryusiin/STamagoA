using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InKinder_Ruler : Ruler
{
    // : Chief
    private InKinder_UIChief UIChief;

    // : Init
    public override void Init()
    {
        // :: Chief
        this.UIChief = GameObject.FindObjectOfType<InKinder_UIChief>();
        this.UIChief.Init();

        // :: Button Scenario
        this.ScenarioButtons();

        // :: Complete Init
        Dictator.Debug_Init(this.ToString());

        // :: Start Scenario
        this.ScenarioStart();
    }

    // : Scenario
    protected override void ScenarioStart()
    {
        // :: Fade
        this.UIChief.FadeIn_Dim(() =>
        {
            Debug.Log("InKinder 시작");
        });
    }
    private void ScenarioButtons()
    {
        this.AddButtonScenario_Training();
        this.AddButtonScenario_Food();
        this.AddButtonScenario_Clean();
        this.AddButtonScenario_Factory();
    }
    protected override void ScenarioEnd()
    {
        throw new System.NotImplementedException();
    }

    // : Add Button Scenario
    private void AddButtonScenario_Training()
    {
        this.UIChief.AddButtonListner_Training(() => { Debug.Log("Training Click"); });
    }
    private void AddButtonScenario_Food()
    {
        this.UIChief.AddButtonListner_Food(() => { Debug.Log("Food Click"); });
    }
    private void AddButtonScenario_Clean()
    {
        this.UIChief.AddButtonListner_Clean(() => { Debug.Log("Clean Click"); });
    }
    private void AddButtonScenario_Factory()
    {
        this.UIChief.AddButtonListner_Factory(() => { Debug.Log("Factory Click"); });
    }
}
