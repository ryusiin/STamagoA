using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum
{
    public enum eError
    {
        NULL_OBJECT = 0,
        NETWORK_CONNECTION_FAILED = 404
    }

    public enum eLog
    {
        INIT
    }

    public enum eScene
    {
        DICTATOR = 0,
        INTRO = 1,
        TITLE = 2,
        IN_KINDER = 3
    }

    public enum eZombie
    {
        EMMA = 1
    }

    // :: 이 밑에 정리

    public enum eAnimation
    {
        IDLE,
        EAT
    }
    public enum eFade
    {
        IN,
        OUT
    }
    public enum eColor
    {
        GREEN,
        YELLOW,
        RED
    }

    public enum eFood
    {
        BASIC_MEAT = 1
    }
    public enum eStatus
    {
        WAITING,
        CURRENT,
        RELEASE,
        FACTORY
    }
}
