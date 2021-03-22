using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOLeader_Zombie : MonoBehaviour
{
    // : Hide
    // >> Status : Const
    const string EXCEPT_CHILD = "Root";
    private void Hide_ZombieModel_All()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.ToString().Contains(EXCEPT_CHILD))
                continue;

            child.gameObject.SetActive(false);
        }
    }

    // : Select
    public void Select_ZombieModel(Enum.eZombie eZombie)
    {
        this.Hide_ZombieModel_All();
        this.Show_ZombieModel(eZombie);
    }

    // : Show
    // >> Assign
    [SerializeField]
    private GameObject ZOMBIE_EMMA;
    [SerializeField]
    private GameObject ZOMBIE_JEONG;
    [SerializeField]
    private GameObject ZOMBIE_ING_WEN;
    private void Show_ZombieModel(Enum.eZombie eZombie)
    {
        switch(eZombie)
        {
            case Enum.eZombie.EMMA:
                this.ZOMBIE_EMMA.SetActive(true);
                break;
            case Enum.eZombie.JEONG:
                this.ZOMBIE_JEONG.SetActive(true);
                break;
            case Enum.eZombie.ING_WEN:
                this.ZOMBIE_ING_WEN.SetActive(true);
                break;

        }
    }
}
