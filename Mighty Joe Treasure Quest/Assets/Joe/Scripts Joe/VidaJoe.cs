using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaJoe : MonoBehaviour {

    public float vidajoe = 100f;
    public Text textovidas;


    static int vidas = 3; 
    float tiempo;

    GameObject enemigo;
    Movimientoenemigo scriptenemigo;

    GameObject barrera;
    Barrera barreramuerte;

    Transform jugador;
    BoxCollider2D box;
    MoJoe script;
    SpriteRenderer sprite;
    Rigidbody2D rigid;
    Animator anim;


    void Awake() {

        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        rigid = jugador.GetComponent<Rigidbody2D>();
        box = jugador.GetComponent<BoxCollider2D>();
        script = jugador.GetComponent<MoJoe>();
        sprite = jugador.GetComponent<SpriteRenderer>();
        anim = jugador.GetComponent<Animator>();
        textovidas.text = "x " + (vidas - 1);
    }

    void Update() {
        if (vidajoe <= 0 && !anim.GetBool("muertosuelo")) {
            anim.SetTrigger("muerto");
            anim.SetBool("muertosuelo",true);
            vidas--;
            if (vidas == 0)
            {
                textovidas.text = "x " + 0;
            }

            else {
                textovidas.text = "x " + (vidas - 1);
            }
            
            if (sprite.flipX == false)
            {
                rigid.AddForce(new Vector2(-36f, 6f), ForceMode2D.Impulse);
                
            }
            else
            {

                rigid.AddForce(new Vector2(36f, 6f), ForceMode2D.Impulse);
            }
            Destroy(rigid);
            Destroy(script);
            Destroy(box);
        }

        if (anim.GetBool("muertosuelo")) {
            tiempo += Time.deltaTime;
            if (tiempo >= 2.5f) {
                if (vidas == 0)
                {
                    Time.timeScale = 0;
                    if (Input.GetKeyDown("x")) {

                        Time.timeScale = 1;
                        Application.LoadLevel(0);

                    }
                }
                else {

                    Application.LoadLevel(4);

                }
            }

        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Enemy" && vidajoe > 0)
        {
            enemigo = col.gameObject;
            scriptenemigo = enemigo.GetComponent<Movimientoenemigo>();
            anim.SetTrigger("daño");
            if (sprite.flipX == false)
            {
                rigid.AddForce(new Vector2(-16f, 6f), ForceMode2D.Impulse);

            }
            else {

                rigid.AddForce(new Vector2(16f, 6f), ForceMode2D.Impulse);
            }

            vidajoe -= scriptenemigo.getdaño();

        }

        else if (col.gameObject.tag == "Barrera" && vidajoe > 0) {
            barrera = col.gameObject;
            barreramuerte = barrera.GetComponent<Barrera>();
            vidajoe -= barreramuerte.getdaño();
        }
        
    }


    public float getvida() {
        return vidajoe;
    }
}
