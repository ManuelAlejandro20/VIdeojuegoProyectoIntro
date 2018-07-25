using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localizador : MonoBehaviour {

    public GameObject FlyingTroopers;
    static bool activoft;
    static bool activo2; 


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FlyingTroopers.SetActive(true);
            gameObject.SetActive(false);
        }

    }

}
