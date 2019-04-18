using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Rigidbody2D player;
    float horizontalMove = 0f;
    public float baseRunSpeed = 20f;
    bool jump = false;
    bool doubleJump = false;
    bool crouch = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * baseRunSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;                        
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;            
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;            
        }
    }

    private void FixedUpdate()
    {
        // Actually move character, never do this in update()
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false; // reset jump after jumping once
        doubleJump = false; // reset double jump after double jumping once
    }
}
