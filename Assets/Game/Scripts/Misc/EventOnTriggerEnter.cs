using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTriggerEnter;
    [SerializeField] private LayerMask layer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layer == (layer | (1 << collision.gameObject.layer)))
        {
            OnTriggerEnter.Invoke();
        }
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
