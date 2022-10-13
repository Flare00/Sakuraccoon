using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour, ControlsGame.IPlayerActions
{
    public ActionSystem action = null;
    void ControlsGame.IPlayerActions.OnCard1(InputAction.CallbackContext context)
    {
        if(action != null)
            action.PlayCard(0);
    }

    void ControlsGame.IPlayerActions.OnCard2(InputAction.CallbackContext context)
    {
        if (action != null)
            action.PlayCard(1);
    }

    void ControlsGame.IPlayerActions.OnCard3(InputAction.CallbackContext context)
    {
        if (action != null)
            action.PlayCard(2);
    }

    void ControlsGame.IPlayerActions.OnCard4(InputAction.CallbackContext context)
    {
        if (action != null)
            action.PlayCard(3);
    }

    void ControlsGame.IPlayerActions.OnCard5(InputAction.CallbackContext context)
    {
        if (action != null)
            action.PlayCard(4);
    }

    void ControlsGame.IPlayerActions.OnMove(InputAction.CallbackContext context)
    {
        if (action != null)
            action.Move(context.ReadValue<Vector2>());
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
        
    }
}
