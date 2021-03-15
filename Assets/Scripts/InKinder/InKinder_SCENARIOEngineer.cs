using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InKinder_SCENARIOEngineer : Engineer
{
    // : Chief
    private InKinder_UIChief UIChief;
    private InKinder_GOChief GOChief;

    // : Engineer
    private STATUSEngineer STATUSEngineer;

    // : Init
    public override void Init(Class_Chiefs chiefs)
    {
        // :: Chief
        this.UIChief = (InKinder_UIChief)chiefs.UIChief;
        this.GOChief = (InKinder_GOChief)chiefs.GOChief;

        // :: Engineer
        this.STATUSEngineer = Dictator.STATUSEngineer;
    }

    // : Scenario
    public void Scenario_Start()
    {
        // :: Get
        Class_Zombie zombie = this.STATUSEngineer.Get_CurrentZombie();

        // :: Set Zombie Character
        this.GOChief.SetZombie(zombie.Info.type);

        // :: Update Calm Down
        this.Scenario_Update();

        // :: Fade
        this.UIChief.FadeIn_Dim(() =>
        {
            Debug.Log("InKinder 시작");
        });
    }
    public void Scenario_Update()
    {
        // :: Get
        Class_Zombie zombie = this.STATUSEngineer.Get_CurrentZombie();

        // :: Update
        float status_CalmDown = zombie.GetStatus_CalmDown();
        this.UIChief.SetStatus_CalmDown(status_CalmDown);
    }
    public void Scenario_Food()
    {
        // : Show Food
        Debug.Log("***** Food를 JSON으로 처리할 지, 여러 번에 걸쳐할지 확인 필요");
        this.GOChief.ShowFood(Enum.eFood.BASIC_MEAT);

        // : Add Calm Down Status
        this.STATUSEngineer.AddStatus_CurrentZombie_CalmDown(1);
    }
    public void Scenario_Training() {
        Debug.Log("Training Click");
    }
    public void Scenario_Clean() {
        Debug.Log("Clean Click");
    }
    public void Scenario_Factory() {
        Debug.Log("Factory Click");
    }

}
