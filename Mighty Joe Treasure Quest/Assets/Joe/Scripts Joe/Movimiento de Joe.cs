﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientodeJoe : MonoBehaviour {

    [SerializeField] bool ensuelo = true;


    public Rigidbody2D rigid;
    bool hola = false;
    bool hola2 = true;


    void awake() {

        rigid = GetComponent<Rigidbody2D>();

    }

	void Start () {
		
	}
	
	void Update () {
		
	}

    void movimiento() {

        if (Input.GetKeyDown("z") && ensuelo) {




        }


    }

    void saltar() { }

    void agacharse() { }
}
