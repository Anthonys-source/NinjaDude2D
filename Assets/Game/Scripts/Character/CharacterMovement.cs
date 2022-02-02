using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour , ICharacterMovement
{
    [HideInInspector] public bool movementEnabled = true;

    [SerializeField] private float maxMovementVelocity = 10.0f;
    [SerializeField] private float movementResponsiveness = 10.0f;
    [SerializeField] private float friction = 10.0f;
    [SerializeField] private float jumpSpeed = 10.0f;

    private ICharacterInput input;
    private IGroundedGetter groundedGetter;
    private Rigidbody2D rb;

    private bool canDoubleJump = false;

    private void Awake()
    {
        input = GetComponent<ICharacterInput>();
        groundedGetter = GetComponent<IGroundedGetter>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.Jump += Jump;
    }

    private void OnDisable()
    {
        input.Jump -= Jump;
    }

    private void FixedUpdate()
    {
        Move();
        if (groundedGetter.IsGrounded)
        {
            canDoubleJump = true;
        }
    }

    private void Jump()
    {
        if (groundedGetter.IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        else if (canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            canDoubleJump = false;
        }
    }
    
    private void Move()
    {
        if (movementEnabled)
        {
            if (input.Movement.x > 0.0f)
            {
                Vector2 targetVelocity = Vector2.right * maxMovementVelocity;
                Vector2 force = ForceFromVelocity(targetVelocity, movementResponsiveness);
                force.y = 0.0f;
                rb.AddForce(force);
            }
            if (rb.velocity.x > -maxMovementVelocity && input.Movement.x < 0.0f)
            {
                Vector2 targetVelocity = -Vector2.right * maxMovementVelocity;
                Vector2 force = ForceFromVelocity(targetVelocity, movementResponsiveness);
                force.y = 0.0f;
                rb.AddForce(force);
            }


            //Apply X Axis Friction
            if (input.Movement.x == 0.0f)
            {
                Vector2 targetVelocity = Vector2.zero;
                Vector2 force = ForceFromVelocity(targetVelocity, friction);
                force.y = 0.0f;
                rb.AddForce(force);
            }
        }
    }

    private Vector2 ForceFromVelocity(Vector2 velocity, float responsiveness)
    {
        Vector2 force = (velocity - rb.velocity) * responsiveness;
        return force;
    }
}
