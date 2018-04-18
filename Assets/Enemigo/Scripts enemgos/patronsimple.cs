using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patronsimple : MonoBehaviour
{

    public Transform puntopartida;
    public Transform puntofinal;
    public Transform localizador;
    public float velocidadenemigo;
    public Transform jugador;
    public float distancia;
    public bool persiguiendo = false;

    // Use this for initialization

    void acercamiento()
    {

        distancia = Vector3.Distance(jugador.position, transform.position);
        if (distancia <= 10)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetTrigger("ataque");
            persiguiendo = true;
            localizador.transform.position = new Vector3(jugador.transform.position.x - 3.3f, puntofinal.transform.position.y, puntofinal.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, localizador.transform.position, velocidadenemigo * Time.deltaTime);
            if (transform.position == localizador.transform.position)
            {
                persiguiendo = true;
            }


        }
        else if (persiguiendo)
        {
            if (transform.position.x > puntofinal.transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            GetComponent<Animator>().SetTrigger("caminata");
            transform.position = Vector3.MoveTowards(transform.position, puntofinal.transform.position, velocidadenemigo * Time.deltaTime);
            if (transform.position == puntofinal.transform.position)
            {
                persiguiendo = false;
            }

        }   

    }

    void Start()
    {

        if (GetComponent<SpriteRenderer>().flipX == false)
        {
            transform.position = puntopartida.transform.position;

        }
        else
        {

            transform.position = puntofinal.transform.position;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!persiguiendo)
        {
            if (GetComponent<SpriteRenderer>().flipX == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, puntofinal.transform.position, velocidadenemigo * Time.deltaTime);
                if (transform.position == puntofinal.transform.position)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }

            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, puntopartida.transform.position, velocidadenemigo * Time.deltaTime);
                if (transform.position == puntopartida.transform.position)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }

            }
        }


        acercamiento();



    }
}
