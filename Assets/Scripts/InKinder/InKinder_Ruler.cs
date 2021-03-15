using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InKinder_Ruler : Ruler, IObserverForChangeStatus
{
    // : Chief
    private InKinder_UIChief UIChief;
    private InKinder_GOChief GOChief;

    // : Engineer
    private InKinder_SCENARIOEngineer SCENARIOEngineer;

    // : Init
    public override void Init()
    {
        // :: Chief
        this.UIChief = GameObject.FindObjectOfType<InKinder_UIChief>();
        this.UIChief.Init();
        this.GOChief = GameObject.FindObjectOfType<InKinder_GOChief>();
        this.GOChief.Init();

        // :: Engineer
        // >> Packing
        Class_Chiefs chiefs = 
            new Class_Chiefs(this.UIChief, this.GOChief);
        // >> Init
        this.SCENARIOEngineer = this.gameObject.AddComponent<InKinder_SCENARIOEngineer>();
        this.SCENARIOEngineer.Init(chiefs);

        // :: Button Scenario
        this.ScenarioButtons();

        // :: Observe
        var dictator = GameObject.FindObjectOfType<Dictator>();
        dictator.RegisterObserver(this);

        // :: Complete Init
        Dictator.Debug_Init(this.ToString());

        // :: Start Scenario
        this.ScenarioStart();
    }

    // : Scenario
    protected override void ScenarioStart()
    {
        this.SCENARIOEngineer.Scenario_Start();
    }
    private void ScenarioButtons()
    {
        // :: Food
        this.UIChief.AddButtonListner_Food(this.SCENARIOEngineer.Scenario_Food);
        this.UIChief.AddButtonListner_Training(this.SCENARIOEngineer.Scenario_Training);
        this.UIChief.AddButtonListner_Clean(this.SCENARIOEngineer.Scenario_Clean);
        this.UIChief.AddButtonListner_Factory(this.SCENARIOEngineer.Scenario_Factory);
    }
    protected override void ScenarioEnd()
    {
    }

    // :: Observer Pattern
    public void UpdateStatus()
    {
        this.SCENARIOEngineer.Scenario_Update();
    }
}
