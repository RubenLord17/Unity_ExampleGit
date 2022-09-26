using System.Collections;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    [Range(1, 10)] public float velocidad; 
    Rigidbody2D rb2d;
    SpriteRenderer spRd;

    bool isJumping = false; 
    [Range(1, 500)] public float potenciaSalto; 


    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();

    }

    void FixedUpdate()
    {

        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");    
        rb2d.velocity = new Vector2(movimientoHorizontal * velocidad, rb2d.velocity.y);

        if (movimientoHorizontal > 0)
        {
            spRd.flipX = false;
        }
        else if (movimientoHorizontal < 0)
        {
            spRd.flipX = true;
        }


        if (Input.GetButton("Jump") && !isJumping)
        {
            rb2d.AddForce(Vector2.up * potenciaSalto, ForceMode2D.Impulse);
            isJumping = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            isJumping = false;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }
    }
}
