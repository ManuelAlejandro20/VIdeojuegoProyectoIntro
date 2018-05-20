﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientoenemigo : MonoBehaviour
{

    private enum states { caminata, ataque }
    private states estadoprincipal;


    public float velocidadenemigo;
    public Transform puntopartida;
    public Transform puntofinal;
    public Transform localizador;
    public float distanciaacercamiento;
    public int daño;

    float distancia;
    bool persiguiendo = false;
    Animator anim;
    SpriteRenderer sprite;
    Transform jugador;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        estadoprincipal = states.caminata;
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start() {

        if (sprite.flipX == false)
        {
            transform.position = puntopartida.transform.position;

        }
        else
        {

            transform.position = puntofinal.transform.position;

        }

    }

    void Update()
    {
        acercamiento();
        IA();
    }

    void IA() {

        switch (estadoprincipal){

            case states.caminata:
                if (!persiguiendo)
                {
                    anim.SetTrigger("Caminata");
                    if (sprite.flipX == false)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, puntofinal.transform.position, velocidadenemigo * Time.deltaTime);
                        if (transform.position == puntofinal.transform.position)
                        {
                            sprite.flipX = true;
                        }

                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, puntopartida.transform.position, velocidadenemigo * Time.deltaTime);
                        if (transform.position == puntopartida.transform.position)
                        {
                            sprite.flipX = false;
                        }

                    }
                }
                break;


            case states.ataque:
                if (distancia <= distanciaacercamiento) {
                    if ((jugador.position.x - transform.position.x) > 1)
                    {
                        sprite.flipX = false;
                        anim.SetTrigger("Ataque");
                        localizador.transform.position = new Vector2(jugador.transform.position.x - 3.3f, puntofinal.transform.position.y);
                        transform.position = Vector3.MoveTowards(transform.position, localizador.transform.position, velocidadenemigo * Time.deltaTime);

                    }
                    else if ((jugador.position.x - transform.position.x) < 1)
                    {
                        sprite.flipX = true;
                        anim.SetTrigger("Ataque");
                        localizador.transform.position = new Vector2(jugador.transform.position.x + 3.3f, puntofinal.transform.position.y);
                        transform.position = Vector3.MoveTowards(transform.position, localizador.transform.position, velocidadenemigo * Time.deltaTime);

                    }

                }
                break;

            default:
                break;
        }
    }

    void acercamiento() {
        distancia = Vector3.Distance(jugador.position, transform.position);
        if (distancia <= distanciaacercamiento)
        {
            estadoprincipal = states.ataque;
            persiguiendo = true;

        }
        else if (persiguiendo) {

            anim.SetTrigger("Caminata");
            transform.position = Vector3.MoveTowards(transform.position, puntofinal.transform.position, velocidadenemigo * Time.deltaTime);

            if (transform.position.x > puntofinal.transform.position.x)
            {
                sprite.flipX = true;
            }

            else if (transform.position.x < puntofinal.transform.position.x)
            {
                sprite.flipX = false;

            }
           
            if (transform.position == puntofinal.transform.position)
            {
                persiguiendo = false;
                estadoprincipal = states.caminata;
            }

        }


    }

    public int getdaño() {
        return daño;
    }
}
