﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patada : MonoBehaviour
{
    private Rigidbody2D bala;
    private GameObject jugador;
    public float bulletspeed;
    public float duracion;
    public static float daño;
    public float dañoref;

    void Awake()
    {

        daño = dañoref;
        jugador = GameObject.FindGameObjectWithTag("Player");


    }

    void Start()
    {
        if (jugador.GetComponent<SpriteRenderer>().flipX == false)
        {
            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(bulletspeed, GetComponent<Rigidbody2D>().velocity.y);

        }
        else
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletspeed, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Destroy(gameObject, duracion);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Enemy")
        {

            Destroy(gameObject);

        }
    }
}
