using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10f;
    public float jumpforce = 5; //cris
    public bool isOnGround = true; //cris
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent <Rigidbody2D>();
        print(message: "Despertar, abrir los ojos");
    }

    
    void Start()
    {
        print(message: "Levantarme");
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) //cris
        {
            _rb.AddForce(Vector2.up*jumpforce, ForceMode2D.Impulse); //cris
            isOnGround = false;
        }

        _rb.velocity = new Vector2(x: speed * horizontalInput, _rb.velocity.y); //cris

    }

    void OnCollisionEnter2D(Collision2D col) //cris
    {
        isOnGround = true;
    }

    private void FixedUpdate() //cris
    {
        
        _rb.velocity = new Vector2(x: speed * horizontalInput, _rb.velocity.y);
    }
}
