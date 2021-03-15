using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InKinder_Ruler : Ruler, IObserver
{
    // : Chief
    private InKinder_UIChief UIChief;
    private InKinder_GOChief GOChief;

    // : Singer
    private STATUSSinger STATUSSinger;

    // : Init
    public override void Init()
    {
        // :: Chief
        this.UIChief = GameObject.FindObjectOfType<InKinder_UIChief>();
        this.UIChief.Init();
        this.GOChief = GameObject.FindObjectOfType<InKinder_GOChief>();
        this.GOChief.Init();

        // :: Singer
        this.STATUSSinger = STATUSSinger.Instance();

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
        // :: Set Zombie Character
        this.SetZombie();

        // :: Update Calm Down
        this.UpdateStatus_CalmDown();

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
    private void ScenarioFood()
    {
        Debug.Log("***** Food를 JSON으로 처리할 지, 여러 번에 걸쳐할지 확인 필요");
        this.GOChief.ShowFood(Enum.eFood.BASIC_MEAT);
        this.STATUSSinger.AddStatus_CurrentZombie_CalmDown(1);
    }
    protected override void ScenarioEnd()
    {
        throw new System.NotImplementedException();
    }

    // : Update
    public void UpdateStatus_CalmDown()
    {
        float percent = this.STATUSSinger.GetStatus_CurrentZombie_CalmDown();
        this.UIChief.SetStatus_CalmDown(percent);
    }

    // : Set
    public void SetZombie()
    {
        Enum.eZombie eZombie = this.STATUSSinger.GetType_CurrentZombie();
        this.GOChief.SetZombie(eZombie);
    }

    // : Add Button Scenario
    private void AddButtonScenario_Food()
    {
        this.UIChief.AddButtonListner_Food(this.ScenarioFood);
    }
    private void AddButtonScenario_Training()
    {
        this.UIChief.AddButtonListner_Training(() => { Debug.Log("Training Click"); });
    }
    private void AddButtonScenario_Clean()
    {
        this.UIChief.AddButtonListner_Clean(() => { Debug.Log("Clean Click"); });
    }
    private void AddButtonScenario_Factory()
    {
        this.UIChief.AddButtonListner_Factory(() => { Debug.Log("Factory Click"); });
    }

    // :: Observer Pattern
    public void UpdateMinute()
    {
        this.UpdateStatus_CalmDown();
    }

    public void UpdateStatus()
    {
        this.UpdateStatus_CalmDown();
    }
}
