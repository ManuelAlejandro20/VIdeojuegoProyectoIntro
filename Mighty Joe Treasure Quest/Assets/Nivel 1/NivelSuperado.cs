using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NivelSuperado : MonoBehaviour {

    GameObject admintesoros;
    AdminTesoros at;

	Canvas canvas;
	AudioSource au;

	bool sonido = true;

	VidaJoe scriptvida;
	GameObject jugador;

	GameObject gameobject_musica;
	AudioSource[] au_gameobject_musica;
    AudioSource au_gameobject_musica2;

    int escena_actual;

    void Awake() {

        admintesoros = GameObject.Find("AdminTesoros");
        at = admintesoros.GetComponent<AdminTesoros>();
		jugador = GameObject.FindGameObjectWithTag ("Player");
		scriptvida = jugador.GetComponent<VidaJoe> ();


		gameobject_musica = GameObject.Find ("Música");
		

		canvas = GetComponent<Canvas> ();
		au = GetComponent<AudioSource> ();
        escena_actual = SceneManager.GetActiveScene().buildIndex;
        if (escena_actual == 3)
        {
            au_gameobject_musica = gameobject_musica.GetComponents<AudioSource>();
            au_gameobject_musica2 = null;

        }
        else
        {
            au_gameobject_musica2 = GetComponent<AudioSource>();
            au_gameobject_musica = null;

        }
    }

	void Start () {
		
	}

	void Update () {

		if (canvas.enabled && sonido) {
            if (au_gameobject_musica2 == null)
            {
                at.eliminartesoros();
                scriptvida.setvida(100f);
                au.Play();
                if (au_gameobject_musica[0].isPlaying)
                {
                    au_gameobject_musica[0].Pause();
                }
                else if (au_gameobject_musica[1].isPlaying)
                {
                    au_gameobject_musica[1].Pause();
                }
            }
            else {

                au_gameobject_musica2.Pause();

            }
			sonido = false;
		}

	}
}
