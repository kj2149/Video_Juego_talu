using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaObjetoCae : MonoBehaviour
{

    public Rigidbody2D objetoCae;
    public float fuerzaCaida;


    private void Start()
    {
        if (fuerzaCaida <= 0) { fuerzaCaida = 10; }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objetoCae.bodyType = RigidbodyType2D.Dynamic;            
            objetoCae.gravityScale = fuerzaCaida;
            Debug.Log("Hit");
        }

        if(collision.gameObject.CompareTag("Enemigo"))
        {

            Destroy(collision.gameObject,0.1f);
            Debug.Log("Hit enemigo");

           
        }
    }
}
