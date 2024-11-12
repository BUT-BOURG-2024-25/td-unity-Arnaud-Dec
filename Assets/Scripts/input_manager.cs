using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;


public class input_manager : Singleton<input_manager>
{
   

    [SerializeField]
    private InputActionReference MovementAction = null;

    [SerializeField]
    private InputActionReference JumpAction = null;

    [SerializeField]
    private InputActionReference MousePositionAction = null;

    

    public UnityEngine.Vector3 MovementInput { get; private set; }

    public Action<Vector2> FingerDownAction = null;

    

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



    public void OnEnable()
    {
        TouchSimulation.Enable();
        EnhancedTouchSupport.Enable();

        Touch.onFingerDown += OnfingerDown;
    }

    private void OnfingerDown(Finger finger)
    {
        Vector2 screenPosTouch = finger.screenPosition;
        RectTransform joystickRec = UiManager.Instance.Joystick.transform as RectTransform;

        bool isInX = joystickRec.offsetMin.x <= screenPosTouch.x && screenPosTouch.x <= joystickRec.offsetMax.x;
        bool isInY = joystickRec.offsetMin.y <= screenPosTouch.y && screenPosTouch.y <= joystickRec.offsetMax.y;

        if (!isInX || !isInY)
        {
            FingerDownAction.Invoke(screenPosTouch);
        }
        
    }

    public void OnDisable()
    {
        Touch.onFingerDown -= OnfingerDown;

        EnhancedTouchSupport.Disable();
        TouchSimulation.Disable();
    }
}
