using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Salida : MonoBehaviour {

	GuardaTesoros script;
	Canvas imagen;
	GameObject sistemacofres;
	GameObject mensaje;

	public Text texto;

	bool escena4;
	bool escena10;

	void Awake(){

		mensaje = GameObject.Find ("NivelSuperado");
		imagen = mensaje.GetComponent<Canvas>();
		imagen.enabled = false;
		sistemacofres = GameObject.Find ("Cofres");
		script = sistemacofres.GetComponent<GuardaTesoros>();
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
			if (script.getcontador() == 3) {
				texto.text = "$" + script.getcantidadtotal ();
				if (script.getcantidadtotal () < 400000) {
						escena4 = true;
					} 

				else {
					escena10 = true;
					}

				}
		}
	}

}
