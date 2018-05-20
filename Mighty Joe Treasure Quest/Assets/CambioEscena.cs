using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour {

	void Update () {
		
	}

    public void primerescenario()
    {

        Application.LoadLevel(1);
    }

    public void Salirdejuego()
    {
        Application.Quit();

    }


}

