using UnityEngine;
using UnityEngine.UI;

public class Intro_UIChief : Chief
{
    // : Assign
    [SerializeField]
    private Image IMAGE_Dim;

    // : Machine
    private FADEMachine FADEMachine;

    // : Init
    public override void Init() {
        this.FADEMachine = this.gameObject.AddComponent<FADEMachine>();
    }

    // : Fade
    public void FadeDim(Enum.eFade eFade, System.Action action = null)
    {
        if (eFade == Enum.eFade.IN)
            this.FADEMachine.FadeIn(this.IMAGE_Dim, action);
        else if (eFade == Enum.eFade.OUT)
            this.FADEMachine.FadeOut(this.IMAGE_Dim, action);
    }
}
