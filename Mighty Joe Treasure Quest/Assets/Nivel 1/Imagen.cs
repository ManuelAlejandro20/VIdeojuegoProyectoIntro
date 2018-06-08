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

    void Awake(){

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

            }
            else if (Input.GetKeyDown("x"))
            {
                    canvas.enabled = false;
                    Time.timeScale = 1;
            }


            

        }


        
	}
}
