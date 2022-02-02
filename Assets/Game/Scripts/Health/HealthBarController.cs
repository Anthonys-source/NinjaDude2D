using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private FloatEventChannelSO HealthChangedEvent;
    private float fullHealthTransformWidth;

    private void OnEnable()
    {
        if (HealthChangedEvent != null)
        {
            HealthChangedEvent.onEventRaised += UpdateHealth;
        }
    }

    private void OnDisable()
    {
        if (HealthChangedEvent != null)
        {
            HealthChangedEvent.onEventRaised -= UpdateHealth;
        }
    }

    private void Start()
    {
        fullHealthTransformWidth = transform.localScale.x;
    }

    public void UpdateHealth(float newHealthPercentage)
    {
        Vector3 newScale = transform.localScale;
        newScale.x = newHealthPercentage * fullHealthTransformWidth;
        transform.localScale = newScale;
    }
}
