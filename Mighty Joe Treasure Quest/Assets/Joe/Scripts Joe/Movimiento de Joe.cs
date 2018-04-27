using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientodeJoe : MonoBehaviour {

    [SerializeField] bool ensuelo = true;
    float tiemposalto = 0f;
    float podersalto = 15f;


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

        tiemposalto += Time.deltaTime;

        if (Input.GetKeyDown("z") && ensuelo) {
            anim.SetBool("parado", false);
            anim.SetBool("saltar", true);
            rigid.velocity = new Vector2(rigid.velocity.x, 0f);
            rigid.AddForce(new Vector2(0f, podersalto), ForceMode.Impulse);
            ensuelo = false;

        }

        if (tiemposalto >= 0.05f) {

            anim.SetBool("saltar", true);
            anim.SetBool("caer", false);
            tiemposalto = 0f;



        }

    }

}
