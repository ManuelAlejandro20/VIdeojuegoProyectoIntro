using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imagen : MonoBehaviour {

    bool activa = true;
    Canvas canvas;
    /*Se asocia el correspondiente cofre al tesoro*/
    public GameObject cofre;

	void Start () {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
	}
	
	void Update () {

        /*Si el cofre es diferente de nulo entonces se desplegará la imagen con el tesoro su valor y la descipción si se 
         presiona X la imagen desaparecerá y se podrá seguir jugando*/
        if (cofre != null) {
            if (cofre.GetComponent<Animator>().GetBool("abierto") && activa)
            {
                canvas.enabled = true;
                Time.timeScale = 0;
                if (Input.GetKeyDown("x"))
                {
                    canvas.enabled = false;
                    Time.timeScale = 1;
                    activa = false;
                }
            }

        }


        
	}
}
