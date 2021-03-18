using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class InKinder_Ruler : Ruler, IObserver_Policy, IObserver_Animation
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
        this.SCENARIOEngineer = new InKinder_SCENARIOEngineer();
        this.SCENARIOEngineer.InitMinister(this.Minister);
        // >> Send
        this.SendChiefs_ToScenario();

        // :: Button Scenario
        this.ScenarioButtons();

        // :: Observe
        this.Minister.POLICYSecretary.RegisterObserver(this);
        this.GOChief.RegisterObserver_ForZombieAnimation(this);

        // :: Complete Init
        Clerk.Log(Enum.eLog.INIT, this.ToString());

        // :: Start Scenario
        this.ScenarioStart();
    }

    // : Send
    public void SendChiefs_ToScenario()
    {
        // :: Packing
        PACKChiefs pack = new PACKChiefs();
        pack.UIChief = this.UIChief;
        pack.GOChief = this.GOChief;

        // :: Send
        this.SCENARIOEngineer.InitChiefs(pack);
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
    public void UpdatePolicy_Status()
    {
        this.SCENARIOEngineer.Scenario_Update();
    }
    public void EndAnimation()
    {
        Debug.Log("***** Animation 종료");
        this.SCENARIOEngineer.Scenario_EndAnimation();
    }
}
