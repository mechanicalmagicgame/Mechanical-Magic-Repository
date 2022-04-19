using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;  //Player Movement Speed
    public float sprintMultiplier;

    private bool isSprinting;  //Sprint Status

    public Rigidbody2D rb;
    //public SpriteRenderer renderer;
    public Animator animator;

    public char lastDir;


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


        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
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

        mx = movement.x;
        my = movement.y;

            if (my > 0 && mx == 0)
                animator.SetFloat("LastDirection", 0); // Up
            else if (my < 0 && mx == 0)
                animator.SetFloat("LastDirection", 1); // Down
            else if (mx > 0 && my == 0)
                animator.SetFloat("LastDirection", 3); //Left
            else if (mx < 0 && my == 0)
                animator.SetFloat("LastDirection", 2); //Right
            else if (my < 0 && mx > 0)
                animator.SetFloat("LastDirection", 4); // Down Left
            else if (my < 0 && mx < 0)
                animator.SetFloat("LastDirection", 5); // Down Right
            else if (my > 0 && mx > 0)
                animator.SetFloat("LastDirection", 6); //Up Left
            else if (my > 0 && mx < 0)
                animator.SetFloat("LastDirection", 7); // Up Right

            Debug.Log(mx + " " + my);
        
    }
}
