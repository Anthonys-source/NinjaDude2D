using UnityEngine;
using UnityEngine.Events;

public abstract class EventListener<T> : MonoBehaviour
{
    public EventChannelSO<T> eventChannel;
    [System.Serializable] public class ParameterEvent : UnityEvent<T> { }
    public ParameterEvent OnEventRaised;

    private void OnEnable()
    {
        eventChannel.onEventRaised += EventRaised;
    }

    private void OnDisable()
    {
        eventChannel.onEventRaised -= EventRaised;
    }

    public void EventRaised(T parameter)
    {
        OnEventRaised?.Invoke(parameter);
    }
}
