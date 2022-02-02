using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour, IDamageable
{
    #region HealthVariables

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    #endregion

    #region Events

    [System.Serializable] public class FloatUnityEvent : UnityEvent<float> { }

    [Header("Events")]
    public FloatUnityEvent OnHealthPercentageChanged = new FloatUnityEvent();
    public UnityEvent OnHit = new UnityEvent();
    public UnityEvent OnDeath = new UnityEvent();

    #endregion

    public void RecieveDamage(float amount)
    {
        CurrentHealth -= amount;
        OnHit?.Invoke();
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0.0f;
            OnDeath?.Invoke();
        }
        OnHealthPercentageChanged.Invoke(currentHealth / maxHealth);
    }

    public void RecieveHeal(float amount)
    {
        CurrentHealth += amount;
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        OnHealthPercentageChanged.Invoke(currentHealth / maxHealth);
    }
}
