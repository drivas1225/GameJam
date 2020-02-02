using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controler;
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
        VerticalMove = Input.GetAxisRaw("Vertical") * runSpeed*3;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            stairs = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            stairs = true;
            
        }
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        if (Input.GetButtonDown("Run"))
        {
            run = true;
        }
        else if (Input.GetButtonUp("Run"))
        {
            run = false;
        }
    }

    void FixedUpdate()
    {
        controler.Move(HorizontalMove*Time.fixedDeltaTime, VerticalMove * Time.fixedDeltaTime, crouch,jump,stairs,run);

        jump = false;

    }
}
