using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controler;
    public Animator animator;
    public float runSpeed = 40f;
    float HorizontalMove = 0f;
    float VerticalMove = 0f;
    bool jump = false;
    bool stairs = false;
    bool crouch = false;
    bool run = false;


    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        VerticalMove = Input.GetAxisRaw("Vertical") * runSpeed * 4;

        animator.SetFloat("Speed", Mathf.Abs( HorizontalMove) );

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            stairs = false;

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            stairs = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            stairs = false;

        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        if (Input.GetButtonDown("Run"))
        {
            run = true;
            animator.SetBool("IsRunning", true);
        }
        else if (Input.GetButtonUp("Run"))
        {
            run = false;
            animator.SetBool("IsRunning", false);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        controler.Move(HorizontalMove*Time.fixedDeltaTime, VerticalMove * Time.fixedDeltaTime, crouch,jump,stairs,run);

        jump = false;

    }
}
