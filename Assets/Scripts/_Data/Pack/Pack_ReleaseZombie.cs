using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pack_ReleaseZombie
{
    // : Constructor
    // >> Status
    public string zombieName;
    public int earningGold;
    public string completeText;
    public Pack_ReleaseZombie(string name, int gold, string complete)
    {
        this.zombieName = name;
        this.earningGold = gold;
        this.completeText = complete;
    }
}
