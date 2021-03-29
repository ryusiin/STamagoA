using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InKinder_UILeader_OX : MonoBehaviour
{
    // : Init
    // >> Assign
    [SerializeField]
    private Button BUTTON_O;
    [SerializeField]
    private Button BUTTON_X;
    // >> Status
    private int gameCount;
    private int gameScore;
    // >> Use
    private enum eOX { O, X }
    public void Init()
    {
        this.BUTTON_O.onClick.AddListener(() => { this.ButtonScenario_O(); });
        this.BUTTON_X.onClick.AddListener(() => { this.ButtonScenario_X(); });
    }
    public void Init_Status()
    {
        this.gameCount = 0;
        this.gameScore = 1;
    }

    // : Button Scenario
    private void ButtonScenario_O()
    {
        this.gameCount += 1;
        Debug.LogWarning("O count" + gameCount);
        this.CheckGame(eOX.O);
        this.CheckCount();
    }
    private void ButtonScenario_X()
    {
        this.gameCount += 1;
        Debug.LogWarning("X count" + gameCount);
        this.CheckGame(eOX.X);
        this.CheckCount();
    }

    // : Check
    // >> Delegate
    public System.Action<int> DelegateEnd_OXGame;
    private void CheckCount()
    {
        if(this.gameCount >= 5)
        {
            this.DelegateEnd_OXGame(this.gameScore);
        }
    }
    private void CheckGame(eOX eOX)
    {
        if (eOX == eOX.O)
            this.gameScore *= 2;
    }
}
