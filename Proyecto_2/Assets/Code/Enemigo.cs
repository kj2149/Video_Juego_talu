using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("Vida enemigo")]
    public int vidaTotal;
    public int vidaActual;
    public int danoRecibir;

    [Header("Ataque Enemigo")]
    public bool ataqueDisparo;
    public float distanciaSeparacion;
    public GameObject player;
    public Vector3 distanciaAPlayer;
    public float velocidadAtaqueEnemigo;

    public GameObject bala;
    public GameObject pistola;
    public float tiempoEsperaBala;
    
   

    [Header("Mirar Player")]
    public SpriteRenderer spriteRenderer;

    [Header("Desplazamiento")]
    public GameObject puntoReposo;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        vidaActual = vidaTotal;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Atacar();
    }

    public void RecibeGolpe() {
        vidaActual = vidaActual - danoRecibir;
        if (vidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Atacar()
    {
        distanciaAPlayer=  player.transform.position - gameObject.transform.position;

        if (ataqueDisparo == false)
        {
            if (Mathf.Abs(distanciaAPlayer.x) <= distanciaSeparacion)
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, velocidadAtaqueEnemigo * Time.deltaTime);
                Debug.DrawLine(transform.position, player.transform.position, Color.red, 0.1f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, puntoReposo.transform.position, 0.01f);
            }
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, puntoReposo.transform.position, 0.01f);
            Debug.Log("Disparo Enemigo");
            StartCoroutine("TiempoDisparo");
            
        }

          
        

        if (player.transform.position.x > gameObject.transform.position.x) { 
            spriteRenderer.flipX = true;
        }
        if (player.transform.position.x < gameObject.transform.position.x)
        {
            spriteRenderer.flipX = false;
        }

        
    }

     IEnumerator TiempoDisparo()
    {
        Debug.Log("Disparo Enemigo");
        Instantiate(bala, pistola.transform.position, quaternion.identity).transform.position = Vector3.MoveTowards(pistola.transform.position, player.transform.position, 5);
        yield return new WaitForSeconds(5);
        Debug.Log("Disparo en espera");
    }

}
