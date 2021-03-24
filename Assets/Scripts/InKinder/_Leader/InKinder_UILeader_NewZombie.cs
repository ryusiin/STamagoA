using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InKinder_UILeader_NewZombie : MonoBehaviour
{
    // : Set
    // >> Assign
    [SerializeField]
    private Text TEXT_Name;
    [SerializeField]
    private Text TEXT_Description;
    public void Set(Pack_NewZombie pack)
    {
        this.TEXT_Name.text = pack.name;
        this.TEXT_Description.text = pack.description;
    }
}
