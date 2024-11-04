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
        physicsBody.AddForce(Vector3.up * jumpPower);
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
        Vector3 NewVelocity = input_manager.Instance.MovementInput * speed;
        NewVelocity.y = physicsBody.velocity.y;
        physicsBody.velocity = NewVelocity;
    }   
}
