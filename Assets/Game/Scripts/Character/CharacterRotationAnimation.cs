using UnityEngine;

public class CharacterRotationAnimation : MonoBehaviour
{
    [SerializeField] private GameObject characterSprite;
    [SerializeField] private float landingRotationSmoothness = 40.0f;
    [SerializeField] private float inAirRotationSmoothness = 40.0f;

    private ICharacterInput input;
    private IGroundedGetter groundedGetter;

    private bool facingRight = true;

    private void Start()
    {
        input = GetComponent<ICharacterInput>();
        groundedGetter = GetComponent<IGroundedGetter>();
    }

    private void Update()
    {
        Orientate();
        if (!groundedGetter.IsGrounded)
        {
            RotateTowardsLook();
        }
        else if(characterSprite.transform.up != Vector3.up)
        {
            if (facingRight)
            {
                Quaternion newRotation = Quaternion.FromToRotation(characterSprite.transform.right, Vector3.right) * characterSprite.transform.rotation;
                characterSprite.transform.rotation = Quaternion.Slerp(characterSprite.transform.rotation, newRotation, Time.deltaTime * landingRotationSmoothness);
            }
            else
            {
                Quaternion newRotation = Quaternion.FromToRotation(characterSprite.transform.right, -Vector3.right) * characterSprite.transform.rotation;
                characterSprite.transform.rotation = Quaternion.Slerp(characterSprite.transform.rotation, newRotation, Time.deltaTime * landingRotationSmoothness);
            }
        }
    }

    private void Orientate()
    {
        if (input.Look.x - characterSprite.transform.position.x > 0.1f && !facingRight)
        {
            //sprite.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            characterSprite.transform.rotation = Quaternion.FromToRotation(transform.right, Vector3.right);
            facingRight = true;
        }
        else if (input.Look.x - characterSprite.transform.position.x < -0.1f && facingRight)
        {
            //sprite.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            characterSprite.transform.rotation = Quaternion.FromToRotation(transform.right, -Vector3.right);
            facingRight = false;
        }
    }

    private void RotateTowardsLook()
    {
        Quaternion newRotation = Quaternion.FromToRotation(characterSprite.transform.right, input.Look - (Vector2)characterSprite.transform.position) * characterSprite.transform.rotation;
        characterSprite.transform.rotation = Quaternion.Slerp(characterSprite.transform.rotation, newRotation, Time.deltaTime * inAirRotationSmoothness);
    }
}
