using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imagen : MonoBehaviour {

    bool activa = true;
    Canvas canvas;
    public GameObject cofre;

	void Start () {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
	}
	
	void Update () {

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
