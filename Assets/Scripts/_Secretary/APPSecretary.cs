using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APPSecretary : Secretary
{
    // : Get
    public bool Get_IsFirstStart()
    {
        Debug.LogWarning(":: 여기 나중에 첫번째 시작인지를 데이터 혹은 PlayerPrefs로 확인해야 함");
        return true;
    }
}
