using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InKinder_UILeader_Button : MonoBehaviour
{
    [Header("Button")]
    [SerializeField]
    private Button BUTTON_Food;
    [SerializeField]
    private Button BUTTON_Training;
    [SerializeField]
    private Button BUTTON_Clean;
    [SerializeField]
    private Button BUTTON_Factory;
    [Header("Strong")]
    [SerializeField]
    private Image IMAGE_Selected;

    // : Add Button Listener
    public void AddButtonListener_Food(System.Action action)
    {
        this.BUTTON_Food.onClick.AddListener(() => { action(); });
    }
    public void AddButtonListener_Training(System.Action action)
    {
        this.BUTTON_Training.onClick.AddListener(() => { action(); });
    }

    // : Can
    public void CanTouchButton(Enum.eButton eButton, bool check)
    {
        Transform buttonTransform = this.transform;
        switch(eButton)
        {
            case Enum.eButton.FOOD:
                this.BUTTON_Food.interactable = check;
                buttonTransform = this.BUTTON_Food.transform;
                break;
            case Enum.eButton.TRAINING:
                this.BUTTON_Training.interactable = check;
                buttonTransform = this.BUTTON_Training.transform;
                break;
            case Enum.eButton.CLEAN:
                this.BUTTON_Clean.interactable = check;
                buttonTransform = this.BUTTON_Clean.transform;
                break;
            case Enum.eButton.FACTORY:
                this.BUTTON_Factory.interactable = check;
                buttonTransform = this.BUTTON_Factory.transform;
                break;
        }

        if (check)
        {
            this.IMAGE_Selected.transform.localPosition =
                buttonTransform.localPosition + new Vector3(0, -7, 0);
            this.IMAGE_Selected.gameObject.SetActive(true);
        }
    }
    public void CanTouchButton_All(bool check)
    {
        this.BUTTON_Food.interactable = check;
        this.BUTTON_Clean.interactable = check;
        this.BUTTON_Training.interactable = check;
        this.BUTTON_Factory.interactable = check;
        this.IMAGE_Selected.gameObject.SetActive(false);
    }
}
