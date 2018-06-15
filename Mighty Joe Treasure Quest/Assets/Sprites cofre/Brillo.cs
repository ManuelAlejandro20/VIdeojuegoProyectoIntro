using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brillo : MonoBehaviour {

	AudioSource sonido;

	void Awake(){
	
		sonido = GetComponent<AudioSource> ();
	
	}


	void efecto(){
	
		sonido.Play ();
	
	}
}
