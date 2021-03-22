using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Secretary : MonoBehaviour
{
    // : public
    protected Minister minister { get; private set; }
    public virtual void Init(Minister Minister)
    {
        this.minister = Minister;
    }
}
