using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZOMBIESecretary : Secretary
{
    // : Init
    // >> Status : Const
    const int BASE_ZOMBIE = 3;
    // >> Status
    public CLASSZombie Zombie_Current { get; private set; }
    public override void Init(Minister Minister)
    {
        base.Init(Minister);
        this.Zombie_Current = this.Get_SavedZombie_Current();
        if (this.Zombie_Current == null)
            this.Zombie_Current = this.CreateZombie(BASE_ZOMBIE);
    }

    // : Create
    public CLASSZombie CreateZombie(int zombieNumber)
    {
        DATAZombie data = 
            this.minister.DATASecretary.DictZombie[zombieNumber];
        CLASSZombie newZombie = new CLASSZombie(data);
        return newZombie;
    }

    // : Get
    private CLASSZombie Get_SavedZombie_Current()
    {
        Debug.LogWarning("나중에 저장된 Current 좀비를 " +
            "우선 확인해서 불러온다. 지금은 스킵");
        return null;
    }
}
