using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : MonoBehaviour
{
    public float movementSpeed;
    private float movs;
    public float jumpPower; 
    Rigidbody2D rigBody;
    private bool isGrounded;
    
    public float doubleTapTime;
    public float dashWaitTime;
    private float lastDashButtonTime;
    private float lastDashTime;
    private bool isDashPossible => Time.time - lastDashTime > dashWaitTime;

    public float dashPower;

    public float moveHori;

    private int jumpCount = 1;
    private bool canDoubleJump;
    
    void Start()
    {
        movs = movementSpeed;
        rigBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        
        moveHori = Input.GetAxis("Horizontal");
        rigBody.velocity = new Vector2(moveHori * movementSpeed, rigBody.velocity.y);
        
        if (Input.GetKeyDown("w"))
        {
            if (isGrounded)
            {
                rigBody.velocity = new Vector2(rigBody.velocity.x, jumpPower);
                isGrounded = false;
            }

        }
        
        if (isDashPossible && Input.GetKeyDown("d") || Input.GetKeyDown("a") ) {
            if (Time.time - lastDashButtonTime < doubleTapTime)
                Dash();
            lastDashButtonTime = Time.time;
        }
    }

    void Dash() {
        print("Dashladi");
        lastDashTime = Time.time;
        movementSpeed += dashPower;
        StartCoroutine(resetSpeed());
    }

    IEnumerator resetSpeed()
    {
        yield return new WaitForSeconds(0.4f);
        movementSpeed = movs;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor") && isGrounded == false)
        {
            isGrounded = true;  
        }
    }
    
}
