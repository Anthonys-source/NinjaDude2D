using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamageController : MonoBehaviour
{
    private List<GameObject> alreadyDamaged = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if(damageable != null && !alreadyDamaged.Contains(collision.gameObject))
        {
            damageable.RecieveDamage(20.0f);
            alreadyDamaged.Add(collision.gameObject);
        }
    }
}
