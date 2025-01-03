using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.InputSystem;

public class input_horizontal_vertical : MonoBehaviour
{

    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private Rigidbody physicsBody;
    [SerializeField]
    private float jumpPower = 5;
    [SerializeField]
    private bool moveWithJoystick = false;

    private void Start()
    {
        input_manager.Instance.RegisterOnJumpInput(Jump, true);

    }

    private void onDestroy()
    {
        input_manager.Instance.RegisterOnJumpInput(Jump, true);
    }


    private void Jump(InputAction.CallbackContext callbackContext)
    {
        if (physicsBody != null)
        {
            physicsBody.AddForce(Vector3.up * jumpPower);
        }
    }

    
    void Update()
    {
        //1

        /*float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Debug.Log("Horizontal: " + Horizontal + "Vertical: " + Vertical);

        Vector3 Mouvement = new Vector3(Horizontal,0, Vertical);

        gameObject.transform.position += Mouvement * speed; */



        //2

        /*Vector3 movementInput = input_manager.Instance.MovementInput;

        gameObject.transform.position += movementInput * speed;*/


        //3 

        if (moveWithJoystick)
        {
            Vector3 joystickDirection = new Vector3(UiManager.Instance.Joystick.Direction.x, 0.0f, UiManager.Instance.Joystick.Direction.y);
            Vector3 NewVelocity = joystickDirection * speed;
            NewVelocity.y = physicsBody.velocity.y;
            physicsBody.velocity = NewVelocity;

        }
        else
        {
            Vector3 NewVelocity = input_manager.Instance.MovementInput * speed;
            NewVelocity.y = physicsBody.velocity.y;
            physicsBody.velocity = NewVelocity;
        }


        }   
}
