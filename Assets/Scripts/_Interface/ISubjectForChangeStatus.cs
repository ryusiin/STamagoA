using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubjectForChangeStatus
{
    void RegisterObserver(IObserverForChangeStatus observer);
    void RemoveObserver(IObserverForChangeStatus observer);
    void NotifyObservers_UpdateStatus();
}
