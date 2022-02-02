using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileController : MonoBehaviour, IProjectile
{
    [SerializeField] private GameObjectSet teamSet;
    [SerializeField] private LayerMask solidLayer;
    [SerializeField] private float damage = 10.0f;

    private Rigidbody2D rb;
    private IDamageDealer damageDealer;
    private bool active = true;

    public UnityEvent OnProjectileHit;

    #region IProjectile Variables
    [HideInInspector] public GameObject Emitter { get; set; }
    public Vector2 Velocity { get => rb.velocity; set => rb.velocity = value; }
    public float AngularVelocity { get => rb.angularVelocity; set => rb.angularVelocity = value; }
    public GameObjectSet TeamSet { get => teamSet; set => teamSet = value; }
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        damageDealer = GetComponent<IDamageDealer>();
    }

    public void Initialize(GameObject emitter, Vector3 velocity, float angularVelocity, float damage)
    {
        Emitter = emitter;
        Velocity = velocity;
        AngularVelocity = angularVelocity;
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
        {
            IDamageable damageableObject = collision.GetComponent<IDamageable>();
            if (collision.gameObject != Emitter && !TeamSet.Items.Contains(collision.gameObject) && damageableObject != null)
            {
                OnProjectileHit.Invoke();
                damageDealer.DealDamage(damageableObject, damage);
                Destroy(this.gameObject);
            }
        }
        if (solidLayer == (solidLayer | (1 << collision.gameObject.layer)))
        {
            OnProjectileHit.Invoke();
            active = false;
            rb.Sleep();
            rb.position = collision.ClosestPoint(rb.position);
        }
    }
}
