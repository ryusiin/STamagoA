using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InKinder_UILeader_CalmDown : MonoBehaviour
{
    // : Assign
    [SerializeField]
    private Image IMAGE_CalmDown;
    [SerializeField]
    private Text TEXT_CalmDown;
    [SerializeField]
    private Sprite SPRITE_Emoji_Happy;
    [SerializeField]
    private Sprite SPRITE_Emoji_Hate;
    [SerializeField]
    private Sprite SPRITE_Emoji_SOSO;
    [SerializeField]
    private Sprite SPRITE_Emoji_CRAZY;

    // : Scenario
    // >> Coroutine
    private Coroutine Coroutine_Crazy = null;
    private void Scenario_Crazy()
    {
        // :: Exit
        if (Coroutine_Crazy != null)
            return;

        // :: Animation
        this.Coroutine_Crazy =
            this.StartCoroutine(this.Scenario_Crazy_Impl());
    }
    private IEnumerator Scenario_Crazy_Impl()
    {
        int count = 0;
        while (true)
        {

            if (count == 0)
                this.SetColor(Const.RGBA_RED);
            else if (count == 1)
                this.SetColor(Const.RGBA_YELLOW);
            else if (count == 2)
                this.SetColor(Const.RGBA_GREEN);

            count += 1;

            // :: Adjust
            if (count > 2)
                count = 0;

            yield return new WaitForSeconds(0.1f);
        }
    }

    // : Set
    public void Set(int cur, int max)
    {
        // :: Calculate
        float percentRaw = (float)cur / (float)max;
        int percent = (int)(percentRaw * 100);

        // :: Set
        this.SetStatus(percent);
        this.SetText(percent);
    }
    private void SetText(int percent)
    {
        string percentString = string.Format("{0}%", percent);
        this.TEXT_CalmDown.text = percentString;
    }
    private void SetStatus(int percent)
    {
        if (percent >= 70)
            this.SetEmoji(this.SPRITE_Emoji_Happy, Const.RGBA_GREEN);
        else if (percent >= 30)
            this.SetEmoji(this.SPRITE_Emoji_SOSO, Const.RGBA_YELLOW);
        else if (percent > 0)
            this.SetEmoji(this.SPRITE_Emoji_Hate, Const.RGBA_RED);
        else
            this.SetEmoji(this.SPRITE_Emoji_CRAZY, CRAZY_COLOR);
    }
    private void SetEmoji(Sprite sprite, string colorRGBA)
    {
        this.IMAGE_CalmDown.sprite = sprite;

        if (colorRGBA == CRAZY_COLOR)
            this.Scenario_Crazy();
        else
        {
            if (this.Coroutine_Crazy != null)
            {
                this.StopCoroutine(this.Coroutine_Crazy);
                this.Coroutine_Crazy = null;
            }
            this.SetColor(colorRGBA);
        }
    }
    // >> Status
    private const string CRAZY_COLOR = "Crazy";
    private void SetColor(string colorRGBA)
    {
        if(ColorUtility.TryParseHtmlString(colorRGBA, out Color color))
        {
            this.IMAGE_CalmDown.color = color;
            this.TEXT_CalmDown.color = color;
        }
    }
}
