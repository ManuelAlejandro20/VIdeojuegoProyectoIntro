using System.Collections;
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


    void Awake()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        scriptvida = jugador.GetComponent<VidaJoe>();
        animator = GetComponent<Animator>();
    }
	
	
	void Update () {

        if (muerte) {
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
            scriptvida.setvida(scriptvida.getvida() - 15f);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Bullet" || col.tag == "Uppercut")
        {

            vida -= Patada.daño;
            if (vida <= 0)
            {
                muerte = true;
                
            }

        }

    }
}
