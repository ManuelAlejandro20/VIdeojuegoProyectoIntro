using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platfmovil : MonoBehaviour {
    public Transform objetivo;
    public float speed;
    private Vector3 principio, fin;
	// Use this for initialization
	void Start () {
        if (objetivo != null)
        {
            objetivo.parent = null;
            principio = transform.position;
            fin = objetivo.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        float Fixedspeed = speed * Time.deltaTime;
        if(objetivo != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, objetivo.position, Fixedspeed);
        }
        if(transform.position == objetivo.position)
        {
            objetivo.position = (objetivo.position == principio)? fin : principio;
        }
    }
}
