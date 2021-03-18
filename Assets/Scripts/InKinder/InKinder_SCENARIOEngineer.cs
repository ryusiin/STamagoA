using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InKinder_SCENARIOEngineer : Engineer
{
    // : Chief
    private InKinder_UIChief UIChief;
    private InKinder_GOChief GOChief;

    // : Init
    protected override void Init()
    {
        // :: Complete
        Clerk.Log(Enum.eLog.INIT, this.ToString());
    }
    public void InitChiefs(PACKChiefs pack)
    {
        // :: Chief
        this.UIChief = (InKinder_UIChief)pack.UIChief;
        this.GOChief = (InKinder_GOChief)pack.GOChief;
    }

    // : Scenario
    public void Scenario_Start()
    {
        // :: Get
        Class_Zombie zombie 
            = this.Minister.DATASecretary.GetZombie_Current();

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
        Class_Zombie zombie = 
            this.Minister.DATASecretary.GetZombie_Current();

        // :: Update
        float status_CalmDown = zombie.GetStatus_CalmDown();
        this.UIChief.SetStatus_CalmDown(status_CalmDown);
        float status_Training = zombie.GetStatus_Training();
        this.UIChief.SetStatus_Trainig(status_Training);
        float status_Deadline = 
            this.Minister.DATASecretary.GetRemainDeadline_CurrentZombie();
        this.UIChief.SetStatus_Deadline(status_Deadline);

        Debug.Log(status_Training);
    }
    public void Scenario_Food()
    {
        // :: Close
        this.UIChief.CanClickButton_All(false);

        // :: Get
        Debug.Log("***** 여기 테스트 중 : 음식 UI를 어떻게 할 것인가");
        Enum.eFood eFood = Enum.eFood.BASIC_MEAT;

        // : Show Food
        Debug.Log("***** Food를 JSON으로 처리할 지, 여러 번에 걸쳐할지 확인 필요");
        this.GOChief.ShowFood(eFood);

        // : Add Calm Down Status
        this.Minister.POLICYSecretary
            .PolicyEat_CurrentZombie(eFood);

        // : Eat Animation
        this.GOChief.PlayAnimation_Eat();
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
    public void Scenario_EndAnimation()
    {
        this.UIChief.CanClickButton_All(true);
    }
}
