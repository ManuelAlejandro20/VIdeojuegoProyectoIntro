using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronMov : MonoBehaviour {

    float distancia;
    public float velocidad = 3f;
    private float velocidadrotacion = 6f;
    public Transform enemigo;
    public Transform objetivo;

	// Use this for initialization
	void Start () {

        objetivo = GameObject.FindWithTag("Player").transform;
		
	}
	
	// Update is called once per frame
	void Update () {

        distancia = Vector3.Distance(objetivo.transform.position, transform.position);
        if (distancia <= 10f) {
            enemigo.rotation = Quaternion.Slerp(enemigo.rotation, Quaternion.LookRotation(objetivo.position - enemigo.position), velocidadrotacion * Time.deltaTime);
            enemigo.position += enemigo.forward * velocidad * Time.deltaTime;
            Debug.DrawLine(objetivo.transform.position, transform.position, Color.green, Time.deltaTime, false);

        }
		
	}
}
