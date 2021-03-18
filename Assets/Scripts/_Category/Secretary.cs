using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Secretary : MonoBehaviour
{
    // : Minister
    protected Minister Minister;
    public void InitMinister(Minister Minister)
    {
        this.Minister = Minister;
    }

    // : Init
    public abstract void Init();
}
