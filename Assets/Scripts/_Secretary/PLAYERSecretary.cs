using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERSecretary : Secretary
{
    // : Init
    // >> Status
    public int Gold_Current { get; private set; }
    public override void Init(Minister Minister)
    {
        base.Init(Minister);
        this.Gold_Current = this.Get_SavedGold();
    }

    // : Add
    public void AddGold(int gold)
    {
        this.Gold_Current += gold;
    }

    // : Get
    private int Get_SavedGold()
    {
        Debug.LogWarning("== 여기서 Save된 골드를 확인해 가져와야 함");
        return 0;
    }
}
