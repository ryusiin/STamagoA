using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FADEMachine : MonoBehaviour
{
    // : Fade
    public void FadeIn(Image image, System.Action action = null)
    {
        this.StartCoroutine(this.FadeIn_Imp(image, action));
    }
    private IEnumerator FadeIn_Imp(Image image, System.Action action)
    {
        // :: Get
        image.gameObject.SetActive(true);
        Color baseColor = image.color;
        
        // :: Loop
        for(float opacity = 1f; 0 <= opacity; opacity -= Time.deltaTime)
        {
            image.color =
                new Color(baseColor.r, baseColor.g, baseColor.b, opacity);

            yield return null;
        }
        image.gameObject.SetActive(false);

        // :: Action
        action?.Invoke();
    }
    public void FadeOut(Image image, System.Action action = null)
    {
        this.StartCoroutine(this.FadeOut_Imp(image, action));
    }
    private IEnumerator FadeOut_Imp(Image image, System.Action action)
    {
        // :: Get
        image.gameObject.SetActive(true);
        Color baseColor = image.color;

        // :: Loop
        for (float opacity = 0f; opacity <= 1f; opacity += Time.deltaTime)
        {
            image.color =
                new Color(baseColor.r, baseColor.g, baseColor.b, opacity);

            yield return null;
        }

        // :: Action
        action?.Invoke();
    }

    // << Text
    // : Fade
    public void FadeIn(Text text, System.Action action = null)
    {
        this.StartCoroutine(this.FadeIn_Imp(text, action));
    }
    private IEnumerator FadeIn_Imp(Text text, System.Action action)
    {
        // :: Get
        text.gameObject.SetActive(true);
        Color baseColor = text.color;
        
        // :: Loop
        for(float opacity = 1f; 0 <= opacity; opacity -= Time.deltaTime)
        {
            text.color =
                new Color(baseColor.r, baseColor.g, baseColor.b, opacity);

            yield return null;
        }
        text.gameObject.SetActive(false);

        // :: Action
        action?.Invoke();
    }
    public void FadeOut(Text text, System.Action action = null)
    {
        this.StartCoroutine(this.FadeOut_Imp(text, action));
    }
    private IEnumerator FadeOut_Imp(Text text, System.Action action)
    {
        // :: Get
        text.gameObject.SetActive(true);
        Color baseColor = text.color;

        // :: Loop
        for (float opacity = 0f; opacity <= 1f; opacity += Time.deltaTime)
        {
            text.color =
                new Color(baseColor.r, baseColor.g, baseColor.b, opacity);

            yield return null;
        }

        // :: Action
        action?.Invoke();
    }
}
