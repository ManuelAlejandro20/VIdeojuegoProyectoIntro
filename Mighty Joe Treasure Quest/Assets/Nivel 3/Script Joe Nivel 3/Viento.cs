using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viento : MonoBehaviour {

    Rigidbody2D rigid;
    public int direccionviento;
    public float tiempo;
    public float cantidad;
    bool direccion;
    void Awake() {

        rigid = GetComponent<Rigidbody2D>();

    }


	void Start () {
		
	}

	void Update () {


        tiempo += Time.deltaTime;
        if (tiempo >= 15f) {

            if (!direccion)
            {
                this.direccionviento = Random.Range(0, 2);
                direccion = true;
                Debug.Log(direccionviento);
            }
            if (direccionviento == 0)
            {
                if (rigid != null) {
                    rigid.AddForce(new Vector2(-cantidad, 0.2f), ForceMode2D.Impulse);
                }
                if (tiempo >= 19f)
                {
                    tiempo = 0;
                    direccion = false;
                }
            }
            else {
                if (rigid != null)
                {
                    rigid.AddForce(new Vector2(cantidad, 0.2f), ForceMode2D.Impulse);
                }
                if (tiempo >= 19f)
                {
                    tiempo = 0;
                    direccion = false;
                }




            }
        }

       

	}
}
