using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventChannelSO<T> : BaseEventChannelSO
{
    public UnityAction<T> onEventRaised;

    public void Raise(T parameter)
    {
        onEventRaised?.Invoke(parameter);
    }
}
