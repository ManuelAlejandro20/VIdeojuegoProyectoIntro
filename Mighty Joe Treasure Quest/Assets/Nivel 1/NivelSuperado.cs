using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NivelSuperado : MonoBehaviour {

	Canvas canvas;
	AudioSource au;

	bool sonido = true;

	GameObject gameobject_musica;
	AudioSource[] au_gameobject_musica;

	void Awake(){
	
		gameobject_musica = GameObject.Find ("Música");
		au_gameobject_musica = gameobject_musica.GetComponents<AudioSource> ();

		canvas = GetComponent<Canvas> ();
		au = GetComponent<AudioSource> ();
	}

	void Start () {
		
	}

	void Update () {

		if (canvas.enabled && sonido) {
			au.Play ();
			if (au_gameobject_musica [0].isPlaying) {
				au_gameobject_musica [0].Pause ();
			} else if (au_gameobject_musica [1].isPlaying) {
				au_gameobject_musica [1].Pause ();
			}
			sonido = false;
		}

	}
}
