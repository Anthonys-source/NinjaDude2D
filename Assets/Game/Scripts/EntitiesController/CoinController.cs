using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinController : MonoBehaviour
{
    [SerializeField] private GameObjectSet playerSet;

    public UnityEvent OnCoinPickedUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerSet.Items.Contains(collision.gameObject))
        {
            OnCoinPickedUp.Invoke();
        }
    }
}
