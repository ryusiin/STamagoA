using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject_Time
{
    void RegisterObserver(IObserver_Time observer);
    void RemoveObserver(IObserver_Time observer);
    void Notify_EverySecond();
    void Notify_EveryMinute();
}
