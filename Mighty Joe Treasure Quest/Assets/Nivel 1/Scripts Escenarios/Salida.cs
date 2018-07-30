using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Salida : MonoBehaviour {

	AdminTesoros at;
    GameObject admintesoros;
    Canvas imagen;
	//GameObject sistemacofres;
	GameObject mensaje;

	public Text texto;

	bool escena4;
	bool escena10;

	void Awake(){

		mensaje = GameObject.Find ("NivelSuperado");
        admintesoros = GameObject.Find("AdminTesoros");
        at = admintesoros.GetComponent<AdminTesoros>();
        imagen = mensaje.GetComponent<Canvas>();
		imagen.enabled = false;
		texto.text = "$" + 0;
	}


	void Start () {
		
	}
		
	void Update () {

		if (escena4 || escena10) {
			imagen.enabled = true;
			Time.timeScale = 0;
			if (Input.GetKeyDown ("x")) {
				imagen.enabled = false;
				Time.timeScale = 1;
				if (escena4) {
					SceneManager.LoadScene (4);
					
				
				} else {
					
					SceneManager.LoadScene (10);
				
				}
			   
			
			}
		}


	}

	public void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (at.getnuminv() == 3) {
				texto.text = "$" + at.valorfinal ();
				if (at.valorfinal () < 400000) {
						escena4 = true;
					} 

				else {
					escena10 = true;
					}

				}
		}
	}

}
