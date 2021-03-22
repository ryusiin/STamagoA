using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InKinder_UILeader_NoticeReleaseZombie : MonoBehaviour
{
    // : Set
    // >> Assign
    [SerializeField]
    private Text TEXT_Name;
    [SerializeField]
    private Text TEXT_Gold;
    [SerializeField]
    private Text TEXT_Complete;
    public void Set(Pack_ReleaseZombie pack)
    {
        this.TEXT_Name.text = pack.zombieName;
        this.TEXT_Gold.text = "+" + pack.earningGold;
        this.TEXT_Complete.text = pack.completeText;
    }
}
