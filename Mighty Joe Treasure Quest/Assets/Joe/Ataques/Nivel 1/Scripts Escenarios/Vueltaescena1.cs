﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Vueltaescena1 : MonoBehaviour {
    public Transform jugador;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            SceneManager.LoadScene("Escenario 1 1er nivel");
        }
            
    }
}
