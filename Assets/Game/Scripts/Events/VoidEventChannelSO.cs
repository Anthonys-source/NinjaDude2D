using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/VoidEventChannelSO")]
public class VoidEventChannelSO : BaseEventChannelSO
{
    public UnityAction onEventRaised;

    public void Raise()
    {
        onEventRaised?.Invoke();
    }
}
