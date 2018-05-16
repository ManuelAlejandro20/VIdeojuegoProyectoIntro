using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour {

    Canvas canvas;
    public bool ewe = false;

	void Start () {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
	
	void Update () {
        
        if (Input.GetKeyDown("space"))
        {
            if (Time.timeScale == 1)
            {
                canvas.enabled = true;
                Time.timeScale = 0;     
            }
            else if (Time.timeScale == 0)
            {
                canvas.enabled = false;
                Time.timeScale = 1;     
            }
        }
    }
}
