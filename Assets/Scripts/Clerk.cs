using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clerk
{
    // : Log
    private static int id = 0;
    private static int LogID
    {
        get { return id += 1; }
    }
    public static void Log(Enum.eLog eLog, string script)
    {
        // :: Convert
        string log = string.Format("{0} :: ", eLog.ToString());
        if (eLog == Enum.eLog.INIT)
            log += string.Format("{0} INIT Complete", script);

        // :: Save
        SaveLog(log);
    }
    public static void LogError(Enum.eError eError, string script)
    {
        // :: Convert
        string log = string.Format("{0} :: ", eError.ToString());
        if (eError == Enum.eError.NULL_OBJECT)
            log += string.Format("{0} has NULL Object", script);
        else if (eError == Enum.eError.NETWORK_CONNECTION_FAILED)
            log += string.Format("Connection Failed in {0}", script);

        // :: Save
        SaveLog(log);
    }

    // : Save
    private static void SaveLog(string log)
    {
        // :: Save
        Dictator.dictLogs.Add(LogID, log);

        // :: Output
        //Debug.Log(log);
    }

    // : App
    public static void AppStatus()
    {
        // :: Convert
        string eLog = Enum.eLog.INIT.ToString();
        string log_AppName = 
            string.Format("{0} :: App Name : {1}",
            eLog, Application.productName);
        string log_AppVersion = 
            string.Format("{0} :: App Version : {1}", 
            eLog, Application.version);

        // :: Save
        Dictator.dictLogs.Add(LogID, log_AppName);
        Dictator.dictLogs.Add(LogID, log_AppVersion);
    }
}
