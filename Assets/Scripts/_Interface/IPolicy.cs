using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPolicy
{
    void RegisterObserver(IObserver_Policy observer);
    void RemoveObserver(IObserver_Policy observer);
    void NotifyObservers_UpdateStatus();
}
