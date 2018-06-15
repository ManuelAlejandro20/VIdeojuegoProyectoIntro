using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imagen : MonoBehaviour {

    Canvas canvas;
    /*Se asocia el correspondiente cofre al tesoro*/
    public GameObject cofre;
    Animator animcofre;
    Cofre scriptcofre;
    float distanciajugadorcofre;

	AudioSource au;

	GameObject gameobject_musica;
	AudioSource[] au_gameobject_musica;

	bool intro = false;
	bool cuerpo = false;

    void Awake(){

		gameobject_musica = GameObject.Find ("Música");
		au_gameobject_musica = gameobject_musica.GetComponents<AudioSource> ();
		au = GetComponent<AudioSource> ();
        scriptcofre = cofre.GetComponent<Cofre>();
        animcofre = cofre.GetComponent<Animator>();
	}


	void Start () {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
	}
	
	void Update () {

        /*Si el cofre es diferente de nulo entonces se desplegará la imagen con el tesoro su valor y la descipción si se 
         presiona X la imagen desaparecerá y se podrá seguir jugando*/

        if (cofre != null) {
            distanciajugadorcofre = cofre.GetComponent<Cofre>().getdistancia();

			
			if (distanciajugadorcofre <= 1.3f && Input.GetKeyDown(KeyCode.UpArrow) && animcofre.GetBool("abierto") && !scriptcofre.getverificartesoro())
            {
                canvas.enabled = true;
                Time.timeScale = 0;
				au.Play ();
				obtener_musica ();

            }
            else if (Input.GetKeyDown("x"))
            {
                canvas.enabled = false;
				Time.timeScale = 1;
				if (intro) {
					au_gameobject_musica [0].UnPause ();
					intro = false;
				} else if (cuerpo) {
					au_gameobject_musica [1].UnPause ();
					cuerpo = false;
				}
            }
				
            


        }


        
	}

	public void obtener_musica(){
		if (au_gameobject_musica [0].isPlaying) {
			intro = true;
			au_gameobject_musica [0].Pause ();
		} else if (au_gameobject_musica [1].isPlaying) {
			cuerpo = true;
			au_gameobject_musica [1].Pause ();
		}
	
	}

}
