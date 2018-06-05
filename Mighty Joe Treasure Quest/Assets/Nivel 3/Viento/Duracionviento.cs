using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duracionviento : MonoBehaviour {

    public int duracion;
    public int velocidad;
    public float tiempo;

    Rigidbody2D rigid;

    void Awake()
    {

        rigid = GetComponent<Rigidbody2D>();


    }

	void Start () {
		
	}


    void Update() {

        tiempo += Time.deltaTime;
        if (tiempo >= 5f) { 
            rigid.velocity = new Vector2(-velocidad, rigid.velocity.y);


            Destroy(gameObject, duracion);
        }
        

        
           
        

        
  
	}
}
