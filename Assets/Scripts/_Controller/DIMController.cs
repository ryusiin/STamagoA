using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DIMController
{
    // : Objects : Image
    public Image IMAGE_Dim;

    // : Const
    const float FADE_IN = 0f;
    const float FADE_OUT = 1f;

    // : Init
    public DIMController(Image IMAGE_Dim)
    {
        this.IMAGE_Dim = IMAGE_Dim;
    }

    // : On
    public void On(bool check)
    {
        this.IMAGE_Dim.gameObject.SetActive(check);
    }

    // : Fade
    public System.Action Callback_FadeIn = null;
    public void FadeIn(float duration)
    {
        // :: Init
        this.SetAlpha(FADE_OUT);
        this.On(true);

        // :: Do
        this.IMAGE_Dim.DOFade(FADE_IN, duration)
            .SetEase(Ease.Linear)
            .onComplete = () => {
                this.On(false);
                this.Callback_FadeIn?.Invoke();
            };
    }
    public System.Action Callback_FadeOut = null;
    public void FadeOut(float duration)
    {
        // :: Init
        this.SetAlpha(FADE_IN);
        this.On(true);

        // :: Do
        this.IMAGE_Dim.DOFade(FADE_OUT, duration)
            .SetEase(Ease.Linear)
            .onComplete = () =>
            {
                this.Callback_FadeOut?.Invoke();
            };
    }

    // : Set
    private void SetAlpha(float alpha)
    {
        Color dimColor = this.IMAGE_Dim.color;
        Color newColor = new Color(dimColor.r, dimColor.g, dimColor.b, alpha);
        this.IMAGE_Dim.color = newColor;
    }
}
