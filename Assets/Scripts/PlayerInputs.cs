using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour, ControlsGame.IPlayerActions
{
    public ActionSystem action = null;

    private Vector2 moveValue;
    private bool isMoving = false;

    void ControlsGame.IPlayerActions.OnCard1(InputAction.CallbackContext context)
    {
        if(action != null && context.performed)
            action.PlayCard(0);
    }

    void ControlsGame.IPlayerActions.OnCard2(InputAction.CallbackContext context)
    {
        if (action != null && context.performed)
            action.PlayCard(1);
    }

    void ControlsGame.IPlayerActions.OnCard3(InputAction.CallbackContext context)
    {
        if (action != null && context.performed)
            action.PlayCard(2);
    }

    void ControlsGame.IPlayerActions.OnCard4(InputAction.CallbackContext context)
    {
        if (action != null && context.performed)
            action.PlayCard(3);
    }

    void ControlsGame.IPlayerActions.OnCard5(InputAction.CallbackContext context)
    {
        if (action != null && context.performed)
            action.PlayCard(4);
    }

    void ControlsGame.IPlayerActions.OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveValue = context.ReadValue<Vector2>();
            isMoving = true;
        }
        else if (context.canceled)
        {
            isMoving = false;
        }
    }

    void ControlsGame.IPlayerActions.OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            action.TogglePause();
        }
    }

    void ControlsGame.IPlayerActions.OnRestart(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            action.Restart();
        }
    }

    void ControlsGame.IPlayerActions.OnSubmit(InputAction.CallbackContext context)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        ControlsGame cg = new ControlsGame();
        cg.Player.SetCallbacks(this);
        cg.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving && action != null)
        {
            action.Move(moveValue);
        }
    }
}
