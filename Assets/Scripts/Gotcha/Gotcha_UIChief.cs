using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gotcha_UIChief : UIChief
{
    // : Init
    // >> Assign
    [Header("Private")]
    [SerializeField]
    private Transform Field_Name;
    [SerializeField]
    private Text Text_Name;
    [SerializeField]
    private Button BUTTON_Gotcha;
    [SerializeField]
    private Button BUTTON_Return;
    public override void Init() {
        this.FADEMachine = this.gameObject.AddComponent<FADEMachine>();
    }

    // : Add Button Listener
    public void AddButtonListener_Gotcha(System.Action action)
    {
        this.BUTTON_Gotcha.onClick.AddListener(() => { action(); });
    }
    public void AddButtonListener_Return(System.Action action)
    {
        this.BUTTON_Return.onClick.AddListener(() => { action(); });
    }

    // : Can
    public void CanClickButton_Gotcha(bool check)
    {
        this.BUTTON_Gotcha.interactable = check;
    }

    // : Show
    public void ShowUI_Name(bool check, string name = "")
    {
        if (name != "")
            this.Text_Name.text = name;

        this.Field_Name.gameObject.SetActive(check);
    }
    public void ShowButton_Return(bool check)
    {
        this.BUTTON_Return.gameObject.SetActive(check);
    }
}
