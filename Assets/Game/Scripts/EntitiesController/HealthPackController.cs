using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackController : MonoBehaviour
{
    [SerializeField] private float healAmount = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable;
        if(collision.TryGetComponent<IDamageable>(out damageable))
        {
            damageable.RecieveHeal(healAmount);
            gameObject.SetActive(false);
        }
    }
}
