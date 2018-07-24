using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubJefe : MonoBehaviour {

    public LayerMask capasuelo;
    public Transform Circulo;
    public float velocidad;
    public float vibracion;


    float tiempo;
    float tiempocamara = 0.6f;
    Rigidbody2D rigid;
    PolygonCollider2D[] pol;
    GameObject ft;
    GameObject camara;
    RectTransform rect;

    bool ensuelo;
    bool subir = false;
    bool temblar = false;
    bool aux = false;

    void Awake() {
        camara = GameObject.Find("Main Camera");
        rect = camara.GetComponent<RectTransform>();
        ft = GameObject.Find("FlyingTroopers");
        pol = ft.GetComponents<PolygonCollider2D>();
        rigid = ft.GetComponent<Rigidbody2D>();

    }


    void Update() {

        ensuelo = Physics2D.OverlapCircle(Circulo.position,  1f, capasuelo);
        
        if (ensuelo && !subir) {
            tiempo += Time.deltaTime;
            if (tiempo >= 4f) {
                tiempo = 0f;
                subir = true;
            }
            
        }

        if (ensuelo && !aux) {
            temblar = true;
            aux = true;
        }

        camaratiembla();

        if (subir) {
            tiempo += Time.deltaTime;
            rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y + velocidad);
            if (tiempo >= 0.6f) {
                tiempo = 0f;
                subir = false;
                aux = false;
            }
        }

    }

    void camaratiembla() {
        if (temblar)
        {
            Vector3 posini = rect.position;
            if (tiempocamara > 0f)
            {
                Vector2 vector = Random.insideUnitSphere * vibracion;
                rect.position = new Vector3(rect.position.x + vector.x, rect.position.y + vector.y, -10f);
                tiempocamara -= Time.deltaTime;
            }
            else
            {
                rect.position = posini;
                tiempocamara = 0.6f;
                temblar = false;
            }
        }
    }



    public void uno() {
        pol[0].enabled = true;
        pol[3].enabled = false;
    }

    public void dos() {
        pol[1].enabled = true;
        pol[0].enabled = false;

    }

    public void tres() {
        pol[2].enabled = true;
        pol[1].enabled = false;

    }

    public void cuatro() {
        pol[3].enabled = true;
        pol[2].enabled = false;

    }
}
