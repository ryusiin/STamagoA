using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clerk
{
    // : Log
    public static void Log_InitComplete(string scriptName)
    {
        string log = string.Format(":: {0} Init Complete", scriptName);
        Debug.Log(log);
    }
}
