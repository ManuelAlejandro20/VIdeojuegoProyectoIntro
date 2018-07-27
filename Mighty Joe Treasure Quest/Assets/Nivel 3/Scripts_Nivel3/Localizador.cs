using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localizador : MonoBehaviour {

    public GameObject FlyingTroopers;
    static bool activoft;
    static bool activo2;
    AudioSource[] au;
    GameObject sonidos;
    bool sonido = false;
	void Awake () {
        sonidos = GameObject.Find("Sonidos");
        au = sonidos.GetComponents<AudioSource>();
	}

	
	// Update is called once per frame
	void Update () {
        if (FlyingTroopers == null && !sonido ) {

            au[1].Play();
            sonido = true;

        }

        if (sonido) {
            gameObject.SetActive(false);
        }
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FlyingTroopers.SetActive(true);
        }

    }

}
