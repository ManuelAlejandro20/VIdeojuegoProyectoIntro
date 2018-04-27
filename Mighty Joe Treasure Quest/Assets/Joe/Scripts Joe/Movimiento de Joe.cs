using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientodeJoe : MonoBehaviour {

    // Estamos volviendo a reescribir el codigo de movimiento de nuestro personaje (osea el script "Mojoe")
    // para hacerlo más ordenado, este script no estaba en la presentación del dia martes.
    [SerializeField] bool ensuelo = true;

    float podersalto = 15f;

    float xd = 2f;
    public Rigidbody2D rigid;
    public Animation anim;


    void awake() {

        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

	void Start () {
		
	}
	
	void Update () {
		
	}

    void salto() {

        if (Input.GetKeyDown("z") && ensuelo) {
            anim.SetBool("joe parado", false);
            anim.SetBool("joe saltar", true);
            rigid.velocity = new Vector2(rigid.velocity.x, 0f);
            rigid.AddForce(new Vector2(0f, podersalto), ForceMode.Impulse);
            ensuelo = false;




        }


    }

}
