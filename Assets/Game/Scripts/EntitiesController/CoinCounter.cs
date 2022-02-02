using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinCounter : MonoBehaviour
{
    private int coins;
    [SerializeField] private IntEventChannelSO addCoinEvent;

    public UnityEvent<string> OnCoinNumberUpdate;

    private void OnEnable()
    {
        addCoinEvent.onEventRaised += AddCoins;
    }

    private void OnDisable()
    {
        addCoinEvent.onEventRaised -= AddCoins;
    }

    public void AddCoins(int number)
    {
        coins += number;
        OnCoinNumberUpdate.Invoke(coins.ToString());
    }
}
