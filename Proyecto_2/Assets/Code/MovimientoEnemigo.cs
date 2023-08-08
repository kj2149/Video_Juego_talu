using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public float velocidadEnemigoReposo;
    public float velocidadEnemigoAtaque;

    public Vector3 distanciaEnemmigoPlayer;
    public float distanciaAceptada;
    public GameObject player;
        SpriteRenderer spriteRenderer;

    [Header("Puntos de recorrido")]    
    public Transform objectoReferencia;
    


    // Start is called before the first frame update
    void Start()
    {
        if (velocidadEnemigoReposo <= 0) { velocidadEnemigoReposo = 0.1f; }
        if (distanciaAceptada <= 0) { distanciaAceptada = 5f; }
        if (velocidadEnemigoAtaque <= 0) { velocidadEnemigoAtaque = 2; }
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        distanciaEnemmigoPlayer = player.transform.position - transform.position;

        if (Mathf.Abs(distanciaEnemmigoPlayer.x) <= distanciaAceptada)
        {
            Debug.Log("cerca");
            Debug.DrawLine(transform.position, player.transform.position, Color.red, 0.1f);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocidadEnemigoAtaque * Time.deltaTime);

            

        }
        else {
            Debug.Log("Lejos");
            if (transform.position != objectoReferencia.position) {
                transform.position = Vector3.MoveTowards(transform.position, objectoReferencia.transform.position, velocidadEnemigoReposo);
            }



           


        }

        void OnCollisionEnter2D (Collider2D other) {
            if (other.gameObject.CompareTag("Player")) {
                Debug.Log("hit Player");
            }
        }
       
     




        if (player.transform.position.x > gameObject.transform.position.x){spriteRenderer.flipX = true;}
        if (player.transform.position.x < gameObject.transform.position.x){spriteRenderer.flipX = false;}

        

        
    }


   
       

    
    
}
