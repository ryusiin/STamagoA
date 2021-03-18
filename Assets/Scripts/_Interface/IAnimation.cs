using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimation
{
    void RegisterObserver(IObserver_Animation observer);
    void RemoveObserver(IObserver_Animation observer);
    void NotifyObservers_EndAnimation();
}
