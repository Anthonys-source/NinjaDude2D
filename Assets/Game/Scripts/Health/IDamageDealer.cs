using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageDealer
{
    public void DealDamage(IDamageable objectToDamage, float amount);
}
