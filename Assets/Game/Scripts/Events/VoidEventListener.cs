using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoidEventListener : MonoBehaviour
{
    public VoidEventChannelSO eventChannel;
    public UnityEvent OnEventRaised;

    private void OnEnable()
    {
        eventChannel.onEventRaised += EventRaised;
    }

    private void OnDisable()
    {
        eventChannel.onEventRaised -= EventRaised;
    }

    public void EventRaised()
    {
        OnEventRaised?.Invoke();
    }
}
