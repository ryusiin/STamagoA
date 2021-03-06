using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TEXTController
{
    // : Constructor
    public TEXTController() { }

    // : Const
    const float FADE_IN = 0f;
    const float FADE_OUT = 1f;

    // : Blink
    public void Blink(Text txt, float duration)
    {
        var blinkSeq = DOTween.Sequence();
        blinkSeq.Append(txt.DOFade(FADE_IN, duration));
        blinkSeq.Append(txt.DOFade(FADE_OUT, duration));
        blinkSeq.SetLoops(-1);
        blinkSeq.Play();
    }

    // : Fade
    public System.Action Callback_FadeIn = null;
    public void FadeIn(Text txt, float duration)
    {
        // :: Init
        this.SetAlpha(txt, FADE_IN);
        txt.gameObject.SetActive(true);

        // :: Do
        txt.DOFade(FADE_OUT, duration)
            .onComplete = () =>
            {
                this.Callback_FadeIn?.Invoke();
            };
    }
    public System.Action Callback_FadeOut = null;
    public void FadeOut(Text txt, float duration)
    {
        // :: Init
        this.SetAlpha(txt, FADE_OUT);
        txt.gameObject.SetActive(true);

        // :: Do
        txt.DOFade(FADE_IN, duration)
            .onComplete = () => {
                txt.gameObject.SetActive(false);
                this.Callback_FadeOut?.Invoke();
            };
    }

    // : Set
    private void SetAlpha(Text txt, float alpha)
    {
        Color dimColor = txt.color;
        Color newColor = new Color(dimColor.r, dimColor.g, dimColor.b, alpha);
        txt.color = newColor;
    }
}
