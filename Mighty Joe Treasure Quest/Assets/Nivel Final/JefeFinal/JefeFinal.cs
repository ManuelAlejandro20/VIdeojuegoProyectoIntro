using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal : MonoBehaviour {

    enum estados {haciafinal, haciainicio, ataque}
    estados estado;

    public List<Vector2> posicionesfin;
    public List<float> distancias;
    public float velocidad;

    Vector2 inicio;
    Animator anim;
    Rigidbody2D rigid;
    int num = -1;
    int ataque;
    float tiempoataque = 0f;

	void Awake () {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        inicio = rigid.position;
        foreach(float distancias in distancias) {
            posicionesfin.Add(inicio + new Vector2(-distancias,0f));
        }

        estado = estados.haciafinal;

	}
	
	void Update () {

        IA();
        
	}

    void IA() {
        switch (estado) {
            case estados.haciafinal:
                if (num == -1)
                {
                    num = Random.Range(0, posicionesfin.Capacity);
                }
                rigid.position = Vector2.MoveTowards(rigid.position, posicionesfin[num], velocidad * Time.deltaTime);
                if (rigid.position == posicionesfin[num]) {
                    ataque = Random.Range(0, 4);
                    if (ataque == 0)
                    {
                        estado = estados.haciainicio;
                    }
                    else {
                        estado = estados.ataque;
                    }

                }

                break;

            case estados.haciainicio:
                rigid.position = Vector2.MoveTowards(rigid.position, inicio, velocidad * Time.deltaTime);
                if (rigid.position == inicio) {
                    num = -1;
                    ataque = Random.Range(0, 4);
                    if (ataque == 0)
                    {
                        estado = estados.haciafinal;
                    }
                    else {
                        estado = estados.ataque;
                    }

                }
                break;

            case estados.ataque:
                anim.SetBool("Normal", false);
                tiempoataque += Time.deltaTime;
                if (ataque == 1)
                {
                    anim.SetTrigger("Ataque");
                }
                else if (ataque == 2 || ataque == 3) {
                    anim.SetTrigger("Proyectil");
                }
                ataque = -1;
                if (tiempoataque >= 4f) {
                    anim.SetBool("Normal", true);
                    tiempoataque = 0f;
                    if (rigid.position == inicio)
                    {
                        estado = estados.haciafinal;
                    }
                    else {
                        estado = estados.haciainicio;
                    }
                }
                break;
           
            default:
                break;
        }
    }
}
