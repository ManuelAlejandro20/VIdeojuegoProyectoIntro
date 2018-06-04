﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaJoe : MonoBehaviour {

    public static float vidajoe = 100f;
    float vidajoe2 = 100f;
    public Canvas terminojuego;
    public Text textovidas;


    static int vidas = 3; 
    float tiempo;

    GameObject enemigo;
    Movimientoenemigo scriptenemigo;

    GameObject barrera;
    Barrera barreramuerte;

    Transform jugador;
    BoxCollider2D box;
    MoJoe script;
    SpriteRenderer sprite;
    Rigidbody2D rigid;
    Animator anim;


    void Awake() {

        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        rigid = jugador.GetComponent<Rigidbody2D>();
        box = jugador.GetComponent<BoxCollider2D>();
        script = jugador.GetComponent<MoJoe>();
        sprite = jugador.GetComponent<SpriteRenderer>();
        anim = jugador.GetComponent<Animator>();
        textovidas.text = "x " + (vidas - 1);
        terminojuego.GetComponent<Canvas>().enabled = false;

        
    }

    void Update() {
        //si es que joe llega a perder una vida, se reiniciara el juego con el descuento de una vida
        if (vidajoe <= 0 && !anim.GetBool("muertosuelo")) {
            anim.SetTrigger("muerto");
            anim.SetBool("muertosuelo",true);
            vidas--;
            if (vidas == 0)
            {
                textovidas.text = "x " + 0;
            }

            else {
                textovidas.text = "x " + (vidas - 1);
            }
            
            if (sprite.flipX == false)
            {
                rigid.AddForce(new Vector2(-36f, 6f), ForceMode2D.Impulse);
                
            }
            else
            {

                rigid.AddForce(new Vector2(36f, 6f), ForceMode2D.Impulse);
            }
            Destroy(rigid);
            Destroy(script);
            Destroy(box);
        }

        //si joe pierde todas las vidas se devolvera la pantalla inicial de juego
        if (anim.GetBool("muertosuelo")) {
            tiempo += Time.deltaTime;
            if (tiempo >= 2.5f) {
                if (vidas == 0)
                {
                    Time.timeScale = 0;
                    terminojuego.GetComponent<Canvas>().enabled = true;
                    if (Input.GetKeyDown("x")) {

                        vidajoe = vidajoe2;
                        vidas = 3;
                        terminojuego.GetComponent<Canvas>().enabled = false;
                        Time.timeScale = 1;
                        SceneManager.LoadScene(0);

                    }
                }
                else {

                    vidajoe = vidajoe2;
                    SceneManager.LoadScene(1);

                }
            }

        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //si es que el enemigo ejecuta daño a Joe a este se le reducira la vida
        if (col.gameObject.tag == "Enemy" && vidajoe > 0)
        {
            enemigo = col.gameObject;
            scriptenemigo = enemigo.GetComponent<Movimientoenemigo>();
            anim.SetTrigger("daño");
            if (sprite.flipX == false)
            {
                rigid.AddForce(new Vector2(-16f, 6f), ForceMode2D.Impulse);

            }
            else {

                rigid.AddForce(new Vector2(16f, 6f), ForceMode2D.Impulse);
            }

            vidajoe -= scriptenemigo.getdaño();

        }
        //la barra de vida sera reducida segun el daño
        else if (col.gameObject.tag == "Barrera" && vidajoe > 0) {
            barrera = col.gameObject;
            barreramuerte = barrera.GetComponent<Barrera>();
            vidajoe -= barreramuerte.getdaño();
        }
        
    }

    //se retorna la vida de joe
    public float getvida() {
        return vidajoe;
    }
}
