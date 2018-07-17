using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaNivel3 : MonoBehaviour {

	VidaJoeNivel3 vida;
	GameObject jugador;
	GameObject[] gmb_musica;
	void Awake(){

		int escena = SceneManager.GetActiveScene ().buildIndex;
		if(escena <= 15 && escena >= 10 ){
			jugador = GameObject.FindGameObjectWithTag ("Player");	
			vida = jugador.GetComponent<VidaJoeNivel3> ();
			DontDestroyOnLoad (this);
			if(FindObjectsOfType(GetType()).Length > 1){
				Destroy (gameObject);
			}

		}

	}

	void Start () {
	}

	void FixedUpdate () {


		if(vida.getvida() <= 0){
			Destroy (gameObject);

		}




	}
}
