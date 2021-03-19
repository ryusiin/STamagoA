using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictator : MonoBehaviour
{
    // : 0 Awake
    private void Awake()
    {
        // :: Check
        this.CheckOverlap();

        // :: Don't Destroy
        DontDestroyOnLoad(this.gameObject);

        // :: Init
        this.Init();
    }

    // : Check
    private void CheckOverlap()
    {
        int hashThis = this.GetHashCode();
        Dictator dictatorFound = GameObject.FindObjectOfType<Dictator>();
        int hashFound = dictatorFound.GetHashCode();
        if (hashThis != hashFound)
            Object.Destroy(dictatorFound.gameObject);
    }

    // : Init
    private void Init()
    {
    }

    // : Censor
    public static void Censor()
    {
    }
}
