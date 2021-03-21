using UnityEngine;
using UnityEngine.UI;

public class Intro_UIChief : UIChief
{
    // : Init
    public override void Init() {
        this.FADEMachine = this.gameObject.AddComponent<FADEMachine>();
    }
}
