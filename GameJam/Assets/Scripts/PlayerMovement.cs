using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controler;
    public float runSpeed = 40f;
    float HorizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

    void FixedUpdate()
    {
        controler.Move(HorizontalMove*Time.fixedDeltaTime,false,false);
    }
}
