using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizadorPlataformas : MonoBehaviour {

    public List<GameObject> plataformas;
    public List<Transform> posiciones;

    void Awake() {
        foreach (GameObject plataformas in plataformas) {
            posiciones.Add(plataformas.transform);
        }
    }

    void Update() {

    }

    public void OnTriggerEnter2D(Collider2D col) {

        if (col.tag == "Player") {
            Debug.Log("xddd");
            for (int i = 0; i < plataformas.Capacity; i++) {
                plataformas[i].transform.position = posiciones[i].position;

            }
        }
    }

    public void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("awa");

        }
    }
}
