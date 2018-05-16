﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    public Transform joe;
    float distancia;
	public GameObject destello;
	public float tiempo = 0.2f;

    void moneda() {

        distancia = Vector3.Distance(joe.position, transform.position);
        if (distancia <= 1.3f && !GetComponent<Animator>().GetBool("abierto") && Input.GetKeyDown(KeyCode.UpArrow)) {

            GetComponent<Animator>().SetBool("abierto", true);
			destello.GetComponent<Animator>().SetBool("brillo", true);


        }
    }

    void Start()
    {
    }

    void Update()
    {

         moneda();
         if (GetComponent<Animator>().GetBool("abierto"))
         {
             tiempo += Time.deltaTime;
             if (tiempo >= 0.4f)
             {

                destello.GetComponent<Animator>().SetBool("brillo", false);
                tiempo = 0f;

             }

         }
    }
}
