﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovEne : MonoBehaviour
{

    public float velocidad;
    public int daño;

    enum states { patrullar, acercarce, atacar }
    states estadoactual;
    GameObject jugador;

    Rigidbody2D rigidenemigo;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    AudioClip[] efectos;
    EnemyHealth script;
    AudioSource au;

    Animator anim;

    Vector2 posicionfinal;
    Vector2 posicioninicial;

    bool moverseinicio = false;
    bool moversefinal = true;

    float distancia;
    public float tiempoataque;

    void Awake()
    {
        au = GetComponent<AudioSource>();
        script = GetComponent<EnemyHealth>();
        efectos = script.getefectos();
        jugador = GameObject.FindGameObjectWithTag("Player");
        rigidenemigo = GetComponent<Rigidbody2D>();
        rigid = jugador.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        posicioninicial = rigidenemigo.position;
        posicionfinal = posicioninicial + new Vector2(-4f, 0f);
        estadoactual = states.patrullar;
    }


    void Start()
    {

    }

    void Update()
    {

        IA();



    }


    void IA()
    {

        if (rigid != null && rigidenemigo != null)
        {
            switch (estadoactual)
            {

                case states.acercarce:

                    anim.SetTrigger("Caminata");
                    
                    rigidenemigo.position = Vector2.MoveTowards(rigidenemigo.position, rigid.position, velocidad * Time.deltaTime);
                    distancia = Vector2.Distance(new Vector2 (rigidenemigo.position.x , 0f), new Vector2(rigid.position.x, 0f));
                    if (rigid.position.x > rigidenemigo.position.x)
                    {
                        sprite.flipX = false;
                    }
                    else
                    {
                        sprite.flipX = true;
                    }

                    if (distancia < 4f)
                    {
                        estadoactual = states.atacar;
                    }

                    else if (distancia > 10f) {
                        if (rigidenemigo.position.x > posicioninicial.x)
                        {
                            sprite.flipX = true;
                            moversefinal = true;
                            moverseinicio = false;
                        }

                        else {

                            sprite.flipX = false;
                            moversefinal = false;
                            moverseinicio = true;

                        }
                        
                        estadoactual = states.patrullar;
                    }
                      

                    break;

                case states.atacar:
                    anim.SetTrigger("Ataque");
                    tiempoataque += Time.deltaTime;
                 
                    if (tiempoataque >= 1.5f)
                    {
                        estadoactual = states.acercarce;
                        tiempoataque = 0f;
                    }

                    break;

                case states.patrullar:

                    anim.SetTrigger("Caminata");

                    if (moversefinal)
                    {
                        sprite.flipX = true;
                        rigidenemigo.position = Vector2.MoveTowards(rigidenemigo.position, posicionfinal, velocidad * Time.deltaTime);
                        if (rigidenemigo.position == posicionfinal)
                        {
                            moverseinicio = true;
                            moversefinal = false;
                        }
                    }

                    if (moverseinicio)
                    {
                        sprite.flipX = false;
                        rigidenemigo.position = Vector2.MoveTowards(rigidenemigo.position, posicioninicial, velocidad * Time.deltaTime);
                        if (rigidenemigo.position == posicioninicial)
                        {
                            moversefinal = true;
                            moverseinicio = false;
                        }
                    }

                    distancia = Vector2.Distance(rigidenemigo.position, rigid.position);
                    if (distancia <= 10f)
                    {
                        estadoactual = states.acercarce;
                    }

                    break;


                default:
                    break;
            }

        }


    }

    public void sonidoataqueespada() {
        au.clip = efectos[1];
        au.Play();
    }

    public int getdaño()
    {
        return daño;
    }

}
