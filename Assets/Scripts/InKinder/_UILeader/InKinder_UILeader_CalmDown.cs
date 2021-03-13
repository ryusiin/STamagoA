using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InKinder_UILeader_CalmDown : Leader
{
    // : Init
    public override void Init()
    {
        // :: Init Complete
        Dictator.Debug_Init(this.ToString());
    }

    // : Assign
    [Header("UI")]
    [SerializeField]
    private Image IMAGE_CalmDown;
    [SerializeField]
    private Text TEXT_CalmDown;
    [Header("Calm Down Emoji")]
    [SerializeField]
    private Sprite SPRITE_Happy;
    [SerializeField]
    private Sprite SPRITE_SoSo;
    [SerializeField]
    private Sprite SPRITE_Angry;
    [SerializeField]
    private Sprite SPRITE_Crazy;

    // : Set
    public void SetStatus(float percent)
    {
        // :: Stabilize
        if(percent >= 1f)
            percent = 1f;
        if (percent <= 0f)
            percent = 0f;

        // :: Set
        this.SetPercent(percent);
        this.SetStatus_Divide(percent);
    } 
    private void SetPercent(float percent)
    {
        string percentText = string.Format("{0}%", (int)(percent*100));
        this.TEXT_CalmDown.text = percentText;
    }
    private Coroutine Coroutine_Color;
    private void SetStatus_Divide(float percent)
    {
        // : Stop Formal
        if (this.Coroutine_Color != null)
            this.StopCoroutine(this.Coroutine_Color);

        if (percent >= 0.5) this.SetStatus_Happy();
        else if (percent >= 0.3) this.SetStatus_SoSo();
        else if (percent > 0) this.SetStatus_Angry();
        else this.SetStatus_Crazy();
    }
    private void SetStatus_Happy()
    {
        this.IMAGE_CalmDown.sprite = this.SPRITE_Happy;
        Color color = COLORSinger.Instance().GetColor(Enum.eColor.GREEN);
        this.SetColor(color);
    }
    private void SetStatus_SoSo()
    {
        this.IMAGE_CalmDown.sprite = this.SPRITE_SoSo;
        Color color = COLORSinger.Instance().GetColor(Enum.eColor.YELLOW);
        this.SetColor(color);
    }
    private void SetStatus_Angry()
    {
        this.IMAGE_CalmDown.sprite = this.SPRITE_Angry;
        Color color = COLORSinger.Instance().GetColor(Enum.eColor.RED);
        this.SetColor(color);
    }
    private void SetStatus_Crazy()
    {
        this.IMAGE_CalmDown.sprite = this.SPRITE_Crazy;
        this.Coroutine_Color = this.StartCoroutine(this.SetColor_Random());
    }
    private IEnumerator SetColor_Random()
    {
        System.Random rand = new System.Random();
        while (true)
        {
            // :: Random Color
            int randColor = rand.Next((int)Enum.eColor.GREEN, (int)Enum.eColor.RED + 1);
            Color color = COLORSinger.Instance().GetColor((Enum.eColor)randColor);
            this.SetColor(color);

            // :: Loop
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void SetColor(Color color)
    {
        this.TEXT_CalmDown.color = color;
        this.IMAGE_CalmDown.color = color;
    }
}