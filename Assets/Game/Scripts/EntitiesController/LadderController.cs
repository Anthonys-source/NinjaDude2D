using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    [SerializeField] private GameObjectSet playerSet;

    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        bc.size = new Vector2(bc.size.x, sr.size.y);
        bc.offset = new Vector2(bc.offset.x, sr.size.y / 2.0f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerSet.Items.Contains(collision.gameObject))
        {
            if(collision.GetComponent<ICharacterInput>().Movement.y > 0.1f)
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 10.0f);
            }
        }
    }
}
