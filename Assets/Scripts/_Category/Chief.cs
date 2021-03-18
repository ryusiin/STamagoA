using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chief : MonoBehaviour
{
    public abstract void Init();
    public virtual void Check_Assign(params object[] objects) {
        foreach(object obj in objects)
        {
            if(obj == null)
            {
                Clerk.LogError(Enum.eError.NULL_OBJECT, this.ToString());
                break;
            }
        }
    }
}
