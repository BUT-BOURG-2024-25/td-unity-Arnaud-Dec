using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;


public class input_manager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference MovementAction = null;
    
    private static input_manager _instance = null;

    [SerializeField]
    private InputActionReference JumpAction = null;

    [SerializeField]
    private InputActionReference MousePositionAction = null;

    public static input_manager Instance
    {
        get { return _instance; }
    }

    public UnityEngine.Vector3 MovementInput { get; private set; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterOnJumpInput(Action<InputAction.CallbackContext> OnJumpAction , bool register)
    {
        if (register)
        {
            JumpAction.action.performed += OnJumpAction;
        }
        else
        {
            JumpAction.action.performed -= OnJumpAction;
        }
    }

    public void RegisterOnClick(Action<InputAction.CallbackContext> OnClickAction, bool register)
    {
        if (register)
        {
            MousePositionAction.action.performed += OnClickAction;
        }
        else
        {
            MousePositionAction.action.performed -= OnClickAction;
        }
    }





    private void Update()
    {
        UnityEngine.Vector2 Movement = MovementAction.action.ReadValue<UnityEngine.Vector2>();
        MovementInput = new UnityEngine.Vector3(Movement.x, 0, Movement.y);
    }
}
