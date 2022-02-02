using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour, IDamageDealer
{
    public void DealDamage(IDamageable objectToDamage,float amount)
    {
        objectToDamage.RecieveDamage(amount);
    }
}
