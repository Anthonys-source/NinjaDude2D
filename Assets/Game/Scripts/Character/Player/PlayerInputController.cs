using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour, ICharacterInput
{
    #region PlayerInput Variables

    public Vector2 Movement { get; private set; } = new Vector2();
    public event UnityAction Jump;
    public Vector2 Look { get; private set; } = new Vector2();
    public Vector2 SpeedFade { get; private set; } = new Vector2();
    public event UnityAction<int> CastAbility;

    #endregion

    #region Helper Variables
    private Variable<bool> jumpProcessedInput = new Variable<bool>(false);
    private IEnumerator jumpSaveTimer;
    private Vector3 worldMousePosition = new Vector3();
    #endregion

    public void OnMove(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (Jump != null && context.performed)
        {
            Jump.Invoke();
        }
    }

    public void OnPrimaryAttack(InputAction.CallbackContext context)
    {
        if (CastAbility != null && context.performed)
        {
            CastAbility.Invoke(0);
        }
    }

    public void OnSecondaryAttack(InputAction.CallbackContext context)
    {
        if (CastAbility != null && context.performed)
        {
            CastAbility.Invoke(1);
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        worldMousePosition = context.ReadValue<Vector2>();
        worldMousePosition.z = 10.0f;
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (CastAbility != null && context.performed)
        {
            CastAbility.Invoke(2);
        }
    }

    public void OnSpeedFade(InputAction.CallbackContext context)
    {
    }

    public void OnReflect(InputAction.CallbackContext context)
    {
        if (CastAbility != null && context.performed)
        {
            CastAbility.Invoke(3);
        }
    }

    private void Update()
    {
        Look = Camera.main.ScreenToWorldPoint(worldMousePosition);
    }

    IEnumerator InputSaveTimer(Variable<bool> variable)
    {
        yield return new WaitForSeconds(0.02f);
        variable.Value = false;
    }

}
