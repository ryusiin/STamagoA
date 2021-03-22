using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IObserver_Time
{
    void UpdateSecond(DateTime time);
    void UpdateMinute(DateTime time);
}
