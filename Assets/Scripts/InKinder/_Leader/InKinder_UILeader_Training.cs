using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InKinder_UILeader_Training : MonoBehaviour
{
    // : Init
    // >> Status
    private Color RED;
    private Color YELLOW;
    private Color GREEN;
    public void Init()
    {
        ColorUtility.TryParseHtmlString(Const.RGBA_RED, 
            out Color redColor);
        this.RED = redColor;
        ColorUtility.TryParseHtmlString(Const.RGBA_YELLOW, 
            out Color yellowColor);
        this.YELLOW = yellowColor;
        ColorUtility.TryParseHtmlString(Const.RGBA_GREEN, 
            out Color greenColor);
        this.GREEN = greenColor;
    }

    // : Set
    // >> Assign
    [SerializeField]
    private Image IMAGE_Fill;
    private void SetColor_Slider(int curTP, int reqTP)
    {
        float percent = (float)curTP / (float)reqTP;
        float addR = (YELLOW.r - RED.r) * percent;
        float addG = (YELLOW.g - RED.g) * percent;
        float addB = (YELLOW.b - RED.b) * percent;
        if (percent < 1)
            this.IMAGE_Fill.color = RED + new Color(addR, addG, addB);
        else
            this.IMAGE_Fill.color = GREEN;
    }
    // >> Assign
    [SerializeField]
    private Slider SLIDER_Training;
    public void SetSlider_Training(CLASSZombie zombie)
    {
        // :: Get
        int curTP = zombie.Get_CurTrainingPoint();

        // :: Set
        this.SLIDER_Training.maxValue = zombie.Get_MaxCalmDown();
        this.SLIDER_Training.value = curTP;

        // :: UI
        this.ShowSlider_ByCurTP(curTP);
        this.SetColor_Slider(curTP, zombie.Get_RequiredTrainingPoint());
    }

    // : Show
    private void ShowSlider_ByCurTP(int curTP)
    {
        if (curTP <= 0)
            this.IMAGE_Fill.gameObject.SetActive(false);
        else
            this.IMAGE_Fill.gameObject.SetActive(true);
    }
}
