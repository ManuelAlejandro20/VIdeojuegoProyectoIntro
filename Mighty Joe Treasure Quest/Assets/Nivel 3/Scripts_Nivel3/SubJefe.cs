using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubJefe : MonoBehaviour {

    public LayerMask capasuelo;
    public Transform Circulo;
    public float velocidad;
    public float vibracion;


    public float tiempo;
    float tiempocamara = 0.6f;
    Rigidbody2D rigid;
    Rigidbody2D rigidjug;
    PolygonCollider2D[] pol;
    GameObject ft;
    GameObject camara;
    GameObject jugador;
    RectTransform rect;

    SpriteRenderer sprite;
    bool ensuelo;
    bool subir = false;
    bool temblar = false;
    bool aux = false;
    bool aux2 = false;
    bool aux3 = false;

    void Awake() {
        camara = GameObject.Find("Main Camera");
        rect = camara.GetComponent<RectTransform>();
        ft = GameObject.Find("FlyingTroopers");
        pol = ft.GetComponents<PolygonCollider2D>();
        rigid = ft.GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        rigidjug = jugador.GetComponent<Rigidbody2D>();
        sprite = ft.GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);

    }


    void Update() {

        ensuelo = Physics2D.OverlapCircle(Circulo.position,  0.3f, capasuelo);
        
        if (ensuelo && !subir) {
            tiempo += Time.deltaTime;
            rigid.bodyType = RigidbodyType2D.Static;
            if (tiempo >= 4f) {
                tiempo = 0f;
                subir = true;
                rigid.bodyType = RigidbodyType2D.Dynamic;
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
            if (tiempo >= 1.1f) {
                tiempo = 0f;
                subir = false;
                aux = false;
                aux3 = true;
                rigid.bodyType = RigidbodyType2D.Static;
            }
        }

        if (aux3 && !aux2) {
            if (rigidjug != null)
            {
                float posx = rigidjug.position.x;
                int posxint = Mathf.RoundToInt(posx);
                if (posx < rigid.position.x)
                {
                    rigid.position = new Vector2(rigid.position.x - 0.4f, rigid.position.y);
                    sprite.flipX = true;
                }
                else
                {
                    rigid.position = new Vector2(rigid.position.x + 0.4f, rigid.position.y);
                    sprite.flipX = false;
                }

                int rigidint = Mathf.RoundToInt(rigid.position.x);

                if (rigidint == posxint)
                {
                    aux2 = true;
                }
            }
                
            
        }

        if (aux2) {
            rigid.bodyType = RigidbodyType2D.Dynamic;
            aux2 = false;
            aux3 = false;
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
