using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D platformBoxCollider;
    [SerializeField] private BoxCollider2D activationBoxCollider;
    [SerializeField] private GameObjectSet playerSet;

    private void Start()
    {
        platformBoxCollider.size = new Vector2(spriteRenderer.size.x, platformBoxCollider.size.y);
        platformBoxCollider.offset = new Vector2(spriteRenderer.size.x / 2.0f, platformBoxCollider.offset.y);
        activationBoxCollider.size = new Vector2(spriteRenderer.size.x, activationBoxCollider.size.y);
        activationBoxCollider.offset = new Vector2(spriteRenderer.size.x / 2.0f, activationBoxCollider.offset.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerSet.Items.Contains(collision.gameObject))
        {
            ICharacterInput ci = collision.GetComponent<ICharacterInput>();
            if (ci.Movement.y < -0.1f)
            {
                Physics2D.IgnoreCollision(platformBoxCollider, collision, true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playerSet.Items.Contains(collision.gameObject))
        {
            Physics2D.IgnoreCollision(platformBoxCollider, collision, false);
        }
    }
}
