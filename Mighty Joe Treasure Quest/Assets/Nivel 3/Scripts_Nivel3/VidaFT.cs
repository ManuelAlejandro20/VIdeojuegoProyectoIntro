﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaFT : MonoBehaviour {

    public float vida;
    VidaJoe scriptvida;
    GameObject jugador;
    Animator animator;
    public GameObject explosiones;
    float tiempo;
    bool muerte = false;
    bool sonidomuerte = false;
    AudioSource[] au;


    void Awake()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        scriptvida = jugador.GetComponent<VidaJoe>();
        animator = GetComponent<Animator>();
        au = GetComponents<AudioSource>();
    }
	
	
	void Update () {

        if (muerte) {
            if (!sonidomuerte) { 
                au[2].Play();
                sonidomuerte = true;
            }
            animator.speed = 2;
            explosiones.SetActive(true);
            tiempo += Time.deltaTime;
            if (tiempo >= 4f) {
                Destroy(gameObject);
            }

        }


	}

    public void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            scriptvida.setvida(scriptvida.getvida() - 10f);
            au[3].Play();
        }

        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Bullet" || col.tag == "Uppercut")
        {
            au[3].Play();
            vida -= Patada.daño;
            if (vida <= 0)
            {
                muerte = true;
                
            }

        }

        if (col.gameObject.name == "ExplosionBomba")
        {

            au[4].Play();
            Debug.Log("xddddd");
            vida -= 85f;

        }

    }


}
