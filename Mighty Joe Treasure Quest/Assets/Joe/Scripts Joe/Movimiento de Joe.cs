using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientodeJoe : MonoBehaviour {

    // Estamos volviendo a reescribir el codigo de movimiento de nuestro personaje (osea el script "Mojoe")
    // para hacer mas ordenado, este script no estaba en la presentación del dia martes.
    [SerializeField] bool ensuelo = true;


    public Rigidbody2D rigid;


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

}
