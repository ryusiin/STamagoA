using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BLINKMachine : MonoBehaviour
{
    public Coroutine Blink(Text text)
    {
        Coroutine coroutine = this.StartCoroutine(this.Blink_Imp(text));
        return coroutine;
    }
    private IEnumerator Blink_Imp(Text text)
    {
        // :: Get
        text.gameObject.SetActive(true);
        Color baseColor = text.color;

        // :: Loop
        Enum.eFade eFade = Enum.eFade.OUT;
        while(true)
        {
            if(eFade == Enum.eFade.OUT)
            {
                for (float opacity = 0f; opacity <= 1f; opacity += Time.deltaTime)
                {
                    text.color =
                        new Color(baseColor.r, baseColor.g, baseColor.b, opacity);

                    yield return null;
                }
                eFade = Enum.eFade.IN;
            } else if(eFade == Enum.eFade.IN)
            {
                for (float opacity = 1f; 0 <= opacity; opacity -= Time.deltaTime)
                {
                    text.color =
                        new Color(baseColor.r, baseColor.g, baseColor.b, opacity);

                    yield return null;
                }
                eFade = Enum.eFade.OUT;
            }
        }
    }
}
