using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Intro_UIChief : MonoBehaviour
{
    // : Holder
    [SerializeField]
    private Image IMAGE_Logo;

    // : Status
    const float LOGO_FADE_OUT = 0f;
    const float LOGO_FADE_IN = 1f;
    const float LOGO_FADE_DURATION = 1f;

    // : Init
    public void Init()
    {
        // :: Init Complete
        Dictator.Debug_Init(this.ToString());
    }

    // : Set
    private void SetAlpha_Logo(float alpha)
    {
        Color curColor = this.IMAGE_Logo.color;
        Color newColor = new Color(curColor.r, curColor.g, curColor.b, alpha);
        this.IMAGE_Logo.color = newColor;
    }
}
