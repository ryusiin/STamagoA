using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIChief : MonoBehaviour
{
    // : Assign
    [Header("Common")]
    [SerializeField]
    protected Image IMAGE_Dim;

    // : Init
    // >> Machine
    protected FADEMachine FADEMachine;
    public abstract void Init();

    // : Fade
    public void FadeDim(Enum.eFade eFade, System.Action action = null)
    {
        if (eFade == Enum.eFade.IN)
            this.FADEMachine.FadeIn(this.IMAGE_Dim, action);
        else if (eFade == Enum.eFade.OUT)
            this.FADEMachine.FadeOut(this.IMAGE_Dim, action);
    }
}
