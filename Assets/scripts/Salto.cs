using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    Rigidbody2D rb2d;
    SpriteRenderer spRd;

    bool isJumping = false; //comprobar si esta o no saltando
    [Range(1, 500)] public float potenciaSalto; //potencia del salto


    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();

    }

    void FixedUpdate()
    {
        
        if (Input.GetButton("Jump") && !isJumping) //pulsar el espacio en caso de que no este saltando
        {
            rb2d.AddForce(Vector2.up * potenciaSalto, ForceMode2D.Impulse); //se aplica fuerza del salto
            isJumping = true; //digo que esta saltando para que no haya doble salto
        } 

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Suelo")) //si el jugador esta colisionando con el suelo o lo que tenga la etiqueta suelo
        {
            isJumping = false; 
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }
    }
}
