using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmovil : MonoBehaviour {

    public GameObject objetivo;
    public float velocidad;
    Vector2 principio, fin;

    Rigidbody2D rigid, rigid_objetivo, rigidjug;

	GameObject jugador;

    void Awake()
    {

        rigid = GetComponent<Rigidbody2D>();
        rigid_objetivo = objetivo.GetComponent<Rigidbody2D>();
		jugador = GameObject.FindGameObjectWithTag ("Player");
		rigidjug = jugador.GetComponent<Rigidbody2D> ();
	}


    void Start()
    {
        principio = rigid.position;
        fin = rigid_objetivo.position;

    }
		
    void FixedUpdate()
    {



        if (rigid != null)
        {
            rigid.position = Vector3.MoveTowards(rigid.position, rigid_objetivo.position, velocidad);

			
		
		}
        if (rigid.position == rigid_objetivo.position)
        {
            rigid_objetivo.position = (rigid_objetivo.position == principio) ? fin : principio;
        }



    }

	public void OnCollisionStay2D(Collision2D col){

		if(col.gameObject.tag == "Player"){
			rigidjug.transform.parent = rigid.transform;

		}
	}

	public void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			rigidjug.transform.parent = null;
		}

	}



}
