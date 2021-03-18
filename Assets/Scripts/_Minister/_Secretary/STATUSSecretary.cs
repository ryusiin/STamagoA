using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STATUSSecretary : Secretary
{
    // : Init
    public override void Init()
    {
        // :: Complete
        Clerk.Log(Enum.eLog.INIT, this.ToString());
    }

    // : Sub
    public void AddStatus_CalmDown(Class_Zombie zombie, int stat)
    {
        zombie.AddStatus_CalmDown(stat);
    }
}
