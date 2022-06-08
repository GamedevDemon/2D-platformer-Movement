using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Movement : MonoBehaviour
{
    // Variables
    private Rigidbody2D _rb;
    public float movespeed = 500f;
    public float jumpForce = 7f;
    
    // Ground Check
    public Transform checkPos;
    public float checkRadius = 0.3f;
    public LayerMask ground;
    private bool grounded;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(checkPos.position, checkRadius, ground);

        float xAxis = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(xAxis * movespeed * Time.deltaTime, _rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            _rb.velocity = Vector2.up * jumpForce; 
        }
    }
}
