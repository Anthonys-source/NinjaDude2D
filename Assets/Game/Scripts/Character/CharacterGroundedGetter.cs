using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGroundedGetter : MonoBehaviour, IGroundedGetter
{

    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;

    public bool IsGrounded { get; private set; }

    private void FixedUpdate()
    {
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        if (Physics2D.BoxCast((Vector2)transform.position + boxCollider.offset, boxCollider.size, 0.0f, -transform.up, 0.015f, groundLayer))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
}
