using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InKinder_UILeader_OX : MonoBehaviour
{
    // : Init
    // >> Assign
    [SerializeField]
    private Text TEXT_Question;
    [SerializeField]
    private Button BUTTON_O;
    [SerializeField]
    private Button BUTTON_X;
    // >> Status
    private int gameCount;
    private int gameScore;
    private Dictionary<int, DATAOX> DictOX;
    public void Init()
    {
        this.BUTTON_O.onClick.AddListener(() => { this.ButtonScenario_O(); });
        this.BUTTON_X.onClick.AddListener(() => { this.ButtonScenario_X(); });
    }
    public void Init_Status(Dictionary<int, DATAOX> DictOX)
    {
        this.gameCount = 0;
        this.gameScore = 1;
        this.DictOX = DictOX;
        this.Set_Question();
    }

    // : Button Scenario
    private void ButtonScenario_O()
    {
        this.CheckGame(true);
    }
    private void ButtonScenario_X()
    {
        this.CheckGame(false);
    }

    // : Set
    // >> Status
    private DATAOX curDataOX;
    public void Set_Question()
    {
        // :: Random
        System.Random rand = new System.Random();
        int oxID = rand.Next(1, this.DictOX.Count + 1);
        this.curDataOX = this.DictOX[oxID];

        // :: Set
        this.TEXT_Question.text = this.curDataOX.question;
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
    private void CheckGame(bool check)
    {
        this.gameCount += 1;
        if (check == this.curDataOX.answer)
        {
            this.gameScore *= 2;
            Debug.LogWarning(":: Correct");
        }
        this.CheckCount();
        this.Set_Question();
    }
}
