using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaNivel1 : MonoBehaviour {

	public AudioClip[] audios;
	AudioSource fuente;
	AudioSource[] ñe;
	bool ñes = false;
	bool ñes2 = false;
	void Awake(){

		ñe = GetComponents<AudioSource> ();
	
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!ñes) {
			ñe [0].clip = audios [0];
			ñe [0].Play ();
			ñes = true;
		}
		if (!ñe [0].isPlaying && !ñes2) {
			ñe [1].clip = audios [1];
			ñe [1].Play ();
			ñe [1].loop = true;
			ñes2 = true;
		
		}
			
	}
}
