using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  Player Movement Script :: Connects Input to Character Controller
 *  Reference: Brackeys - https://www.youtube.com/watch?v=_QajrabyTJc
 */

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    public Vector3 startingPosition;

    // Private Vars
    private Vector3 _velocity;
    private bool _isGrounded;
    private float _speedMultiplier = 1f;

    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * _speedMultiplier * Time.deltaTime);

        // Get Button to do Continuous Jumping
        if (Input.GetButton("Jump") && _isGrounded)
        {
            // Based off of real Physics SQRT(h * -2 * g)
            _velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Check if we are Holding Shift
        if (Input.GetButton("Fire3"))
        {
            _speedMultiplier = 1.5f;
        }
        else
        {
            _speedMultiplier = 1f;
        }

        // Gravity is multiplied by Time^2, so we multiply again in Move()
        _velocity.y += gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);

        // Check if we are falling out of the world
        if (transform.position.y <= -64f)
        {
            _velocity.y = 0f;
            transform.position = startingPosition;

        }
    }
}
