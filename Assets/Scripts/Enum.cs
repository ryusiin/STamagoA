using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum {
    public enum eScene
    {
        DICTATOR = 0,
        INTRO = 1,
        TITLE = 2,
        IN_KINDER = 3
    }
    public enum eFade
    {
        IN,
        OUT
    }
    public enum eError
    {
        NETWORK_CONNECTION_FAILED = 404
    }
    public enum eColor
    {
        GREEN,
        YELLOW,
        RED
    }
    public enum eZombie
    {
        EMMA = 1
    }
    public enum eStatus
    {
        WAITING,
        CURRENT,
        RELEASE,
        FACTORY
    }
}
