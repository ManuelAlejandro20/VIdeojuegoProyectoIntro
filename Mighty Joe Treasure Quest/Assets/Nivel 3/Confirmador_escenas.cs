﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Confirmador_escenas : MonoBehaviour {

    GameObject jugador;
    Rigidbody2D rigid;
    GameObject camara;
    RectTransform rect;

    static int escena_actualest;
    int escena_actual;

    static bool cambiar_escena = false;

    void Awake() {

        

        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Update() {


        escena_actual = SceneManager.GetActiveScene().buildIndex;

        if (jugador == null) {
            jugador = GameObject.FindGameObjectWithTag("Player");
            rigid = jugador.GetComponent<Rigidbody2D>();
            camara = GameObject.Find("Main Camera");
            rect = camara.GetComponent<RectTransform>();
        }


        if (!cambiar_escena) {

            escena_actualest = escena_actual;
            cambiar_escena = true;

        }

        if (escena_actual != escena_actualest) {
            cambiar_escena = false;
        }

        posicionjoe();


    }

    void posicionjoe() {

        if (escena_actual >= 10 && escena_actual <= 15)
        {
            if (escena_actualest == escena_actual + 1)
            {
                if (escena_actual == 10)
                {

                    rigid.position = new Vector2(63.46f, 15.32f);
                    rect.position = new Vector3(52f, 14.87669f, -10f);

                }

                else if (escena_actual == 11)
                {
                    rigid.position = new Vector2(60.649f, 21.865f);
                    rect.position = new Vector3(52f, 22f, -10f);
                }
                /*else if (escena_actual == 12)
                {

                }
                else if (escena_actual == 13)
                {


                }
                else if (escena_actual == 14)
                {

                }*/
                




            }

            
        }
        else {

            Destroy(gameObject);

        }


    }





















    /*string escena_actual;

    void Awake() {

        string e = PlayerPrefs.GetString("Ultima Escena", null);

        if (e == null)
        {
            escena_actual = SceneManager.GetActiveScene().name;
        }
    }

    void Start () {
		
	}

    void Update() {
       
        PlayerPrefs.SetString("Ultima Escena", escena_actual);
        PlayerPrefs.Save();
        
	}*/
}
