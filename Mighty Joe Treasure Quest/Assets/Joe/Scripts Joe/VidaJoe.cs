using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJoe : MonoBehaviour {

    public float vidajoe = 100f;

    Transform jugador;
    SpriteRenderer sprite;
    Rigidbody2D rigid;
    Animator anim;


    void Awake() {

        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        rigid = jugador.GetComponent<Rigidbody2D>();
        sprite = jugador.GetComponent<SpriteRenderer>();
        anim = jugador.GetComponent<Animator>();
    }

    void Update() {
        if (vidajoe <= 0) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            anim.SetTrigger("daño");
            if (sprite.flipX == false)
            {
                rigid.AddForce(new Vector2(-16f, 6f), ForceMode2D.Impulse);

            }
            else {

                rigid.AddForce(new Vector2(16f, 6f), ForceMode2D.Impulse);
            }
            
            Debug.Log("xdd");
            vidajoe -= 10f;
        }

    }
}
