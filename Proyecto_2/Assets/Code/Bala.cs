using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bala : MonoBehaviour
{
    public float velocidadBala;
         GameObject player;
         int direccion;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player.GetComponent<MovimientoSaltoPlayer>().giroBala==1){
            direccion = 1;
            Debug.Log("Derecha");
        }
        else if (player.GetComponent<MovimientoSaltoPlayer>().giroBala == -1)
        {
            direccion = -1;
            Debug.Log("Izquierda");
        }


        if (velocidadBala <= 0) {velocidadBala = 1;}
    }


// Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * velocidadBala * direccion * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemigo")) {
            other.gameObject.GetComponent<VidaEnemigo>().EnemigoRecibeGolpe(1);

            Debug.Log("hit");
            Destroy(gameObject);
        }
    }

}
