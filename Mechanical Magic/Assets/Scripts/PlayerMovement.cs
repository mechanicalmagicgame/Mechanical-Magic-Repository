using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;  //Player Movement Speed
    public float sprintMultiplier;

    private bool isSprinting;  //Sprint Status

    public Rigidbody2D rb;

    Vector2 movement;


    // Update is called once per frame
    void Update()
    {
        if(StateManager.ActiveState != State.Default) {
            rb.velocity *= 0;
            return;
        }
        MovementInput();

        if(Input.GetKey(KeyCode.LeftShift))  //Detect shift press
        {
            isSprinting = true;  //Sprint on while shift is pressed
        }
        else
        {
            isSprinting = false;  //Sprint off while shift is not pressed
        }
    }

    private void FixedUpdate()
    {
        if(StateManager.ActiveState != State.Default) return;
        if(isSprinting)
        {
            rb.velocity = movement * movementSpeed * sprintMultiplier;
        }
        else
        {
            rb.velocity = movement * movementSpeed;
        }
    }

    void MovementInput()
    {
        float mx = Input.GetAxisRaw("Horizontal");  //Movement x
        float my = Input.GetAxisRaw("Vertical");  //Movement y

        movement = new Vector2(mx, my).normalized;
    }
}
