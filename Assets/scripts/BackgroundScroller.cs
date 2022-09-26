using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f,1f)] //hasta donde puede llegar
    public float scrollspeed = 0.5f; //velocidad a la que se mueve el fondo y esta limitada
    private float offset; //es para la especificacion dle movimiento horizontal y como solo hay un valor no hay movimiento vertical solo horizontal 
    private Material mat; //este es la variable del material 
    void Start()
    {
        mat = GetComponent<Renderer>().material; //para conseguir el material 
    }

    
    void Update()
    {
        offset += (Time.deltaTime * scrollspeed) / 10f;
        mat.SetTextureOffset("_MainTex" , new Vector2(offset, 0));
    }                             // nombre de la textura 
}