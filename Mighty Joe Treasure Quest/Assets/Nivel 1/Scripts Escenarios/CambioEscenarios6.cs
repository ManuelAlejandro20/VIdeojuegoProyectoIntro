using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioEscenarios6 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Limite")
        {
            SceneManager.LoadScene("nivel 6 primer escenario", LoadSceneMode.Single);
        }
    }
}
