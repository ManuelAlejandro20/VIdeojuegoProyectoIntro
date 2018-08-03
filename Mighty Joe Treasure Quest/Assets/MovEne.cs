using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovEne : MonoBehaviour {

    public float velocidad;

    enum states {patrullar, acercarce, atacar}
    states estadoactual;
    GameObject jugador;

    Rigidbody2D rigidenemigo;
    Rigidbody2D rigid;

    float distancia;

    void Awake() {
        jugador = GameObject.FindGameObjectWithTag("Player");
        rigidenemigo = GetComponent<Rigidbody2D>();
        rigid = jugador.GetComponent<Rigidbody2D>();
    }


	void Start () {
        
	}
	
	void Update () {

        if(rigid != null && rigidenemigo != null) {
            distancia = Vector2.Distance(rigidenemigo.position, rigid.position);
            if (distancia < 8f) {
                rigidenemigo.position = Vector2.MoveTowards(rigidenemigo.position, rigid.position, velocidad * Time.deltaTime);
                if (distancia < 3f) {
                    estadoactual = states.atacar;
                }

            }
        }


	}

    /*
    void IA {
        switch(estadoactual)

    }*/
}
