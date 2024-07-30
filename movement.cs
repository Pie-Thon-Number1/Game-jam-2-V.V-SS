using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;
    public float sprintSpeed;
    public ParticleSystem speedLines;
    Vector2 moveValue;
    float currSpeed;


    void Start()
    {
        currSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //epic
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0){velocity.y = -2f;}
        if (Input.GetKey(KeyCode.LeftShift)) { 
            currSpeed = sprintSpeed;
            if (!speedLines.isPlaying) speedLines.Play();
        }
        else { 
            currSpeed= speed;
            if (speedLines.isPlaying) speedLines.Stop();
        }


        moveValue.x = Input.GetAxis("Horizontal");
        moveValue.y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveValue.x + transform.forward * moveValue.y;
        controller.Move(move * currSpeed * Time.deltaTime);
            
        

        if ((Input.GetKey("space")) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}