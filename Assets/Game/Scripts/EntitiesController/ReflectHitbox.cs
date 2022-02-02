using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectHitbox : MonoBehaviour
{
    public GameObjectSet newTeam;
    public GameObject newEmitter;
    public Vector2 newDirection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IProjectile projectile = collision.GetComponent<IProjectile>();
        if (projectile != null)
        {
            projectile.TeamSet = newTeam;
            projectile.Emitter = newEmitter;
            projectile.Velocity = projectile.Velocity.magnitude * CalculateDirection(newDirection);
        }
    }

    private Vector2 CalculateDirection(Vector2 direction)
    {
        float randomFactor = UnityEngine.Random.Range(-0.5f, 0.5f);
        Vector3 newDirection = Quaternion.Euler(0.0f, 0.0f, 25.0f * randomFactor) * direction;
        return newDirection.normalized;
    }
}
