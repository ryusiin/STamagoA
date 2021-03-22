using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ruler : MonoBehaviour
{
    // : Awake
    [SerializeField]
    private bool isTest = false;
    private void Awake()
    {
        if (isTest)
        {
            Minister tempMinister = this.gameObject.AddComponent<Minister>();
            this.Init(tempMinister);
        }
        else
            Dictator.Censor();
    }

    // : Init
    // >> Minister
    protected Minister minister { get; private set; }
    public void Init(Minister Minister)
    {
        // :: Minister
        this.minister = Minister;

        // :: Init
        this.InitChief();
        this.InitStatus();
        this.InitButtons();

        // :: Complete
        Clerk.Log_InitComplete(this.ToString());

        // :: DO Next Frame
        this.Do_NextFrame(this.StartRuler);
    }
    protected abstract void InitChief();
    protected abstract void InitStatus();
    protected abstract void InitButtons();

    // : Do
    protected void Do_NextFrame(System.Action action)
    {
        this.StartCoroutine(this.Do_NextFrame_Impl(action));
    }
    private IEnumerator Do_NextFrame_Impl(System.Action action)
    {
        yield return null;
        action();
    }
    protected void Do_NextSeconds(System.Action action, float seconds = 1f)
    {
        this.StartCoroutine(this.Do_NextSeconds_Impl(action, seconds));
    }
    private IEnumerator Do_NextSeconds_Impl(System.Action action, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        action();
    }

    // : Scenario
    protected abstract void StartRuler();
}
