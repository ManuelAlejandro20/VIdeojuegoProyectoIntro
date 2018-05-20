using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour {

    public Image barra;

    VidaJoe scriptvida;
    GameObject jugador;


    void Awake() {
        jugador = GameObject.FindGameObjectWithTag("Player");
        scriptvida = jugador.GetComponent<VidaJoe>();
    }

	void Update () {

        vidabarra(scriptvida.getvida());

	}

    void vidabarra(float vida) {

        barra.fillAmount = (vida/100f);

    }
}
