using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

    public Transform personaje;
    public float margen = 4f;

    Vector3 fase;

    void Start() {
        fase = transform.position - personaje.position;

    }

    void FixedUpdate() {
        Vector3 posicionpersonaje = personaje.position + fase;
        transform.position = Vector3.Lerp(transform.position, posicionpersonaje, margen * Time.deltaTime);
    }

   

    
}

