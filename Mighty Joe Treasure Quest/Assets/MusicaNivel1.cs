﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaNivel1 : MonoBehaviour {

	public AudioClip[] audios;
	VidaJoe vida;
	GameObject jugador;
	AudioSource[] aus;
	bool intro = false;
	bool loop = false;
	void Awake(){

		int escena = SceneManager.GetActiveScene ().buildIndex;
		if(escena <= 3 || escena >= 1 ){
			jugador = GameObject.FindGameObjectWithTag ("Player");	
			vida = jugador.GetComponent<VidaJoe> ();
			aus = GetComponents<AudioSource> ();
			DontDestroyOnLoad (gameObject);
		}


		
		

		
	}

	void Start () {
	}

	void FixedUpdate () {

		if (!loop) {

			aus [1].PlayDelayed (audios[0].length+0.0008f);
			loop = true;
		}

		if(vida.getvida() <= 0){
			Destroy (gameObject);

		}
		
			
	}
		



}