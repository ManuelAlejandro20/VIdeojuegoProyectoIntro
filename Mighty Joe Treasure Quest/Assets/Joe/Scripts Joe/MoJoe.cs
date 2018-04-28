using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class MoJoe : MonoBehaviour {

    [SerializeField] bool ensuelo = true;
    [SerializeField] Transform chequearsuelo;

    bool disparo = false;
    Rigidbody2D rigid;
    Animator anim;

    public LayerMask capasuelo;
    public GameObject proyectilprefab;

    float podersalto = 18f;
    float velocidad = 6f;
    float radiocirculosuelo = 0.05f;
    public float tiempodisparo = 0f;
    float tiemposalto = 0f;


    void Awake() {

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

    }
  
    void Start() {

            
    }  
      
	void Update () {

        movimientos();

    }

    void movimientos() {

        tiemposalto += 2f * Time.deltaTime;

        if (ensuelo && Input.GetKeyDown("z"))
        {
            anim.SetBool("parado", false);
            anim.SetBool("saltar", true);
            rigid.velocity = new Vector2(rigid.velocity.x, 0f);
            rigid.AddForce(new Vector2(0, podersalto), ForceMode2D.Impulse);
            ensuelo = false;

        }

        if (tiemposalto >= 0.2f)
        {
            anim.SetBool("saltar", false);
            anim.SetBool("caer", false);
            tiemposalto = 0;
        }


        if (!ensuelo && !anim.GetBool("saltar"))
        {
            ensuelo = Physics2D.OverlapCircle(chequearsuelo.position, radiocirculosuelo, capasuelo);
            anim.SetBool("caminando y salto", ensuelo);
        }

        ensuelo = Physics2D.OverlapCircle(chequearsuelo.position, radiocirculosuelo, capasuelo);
        anim.SetBool("parado", ensuelo);

        if (Input.GetKey(KeyCode.RightArrow) && !anim.GetBool("agacharse") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Patada"))
        {
            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            anim.SetBool("parado", false);
            anim.SetBool("caminando", true);
            rigid.velocity = new Vector2(velocidad, rigid.velocity.y);
        }

        else if (Input.GetKeyUp(KeyCode.RightArrow) && ensuelo && !anim.GetBool("patada"))
        {
            anim.SetBool("caminando", false);
            anim.SetBool("parado", true);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !anim.GetBool("agacharse") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Patada"))
        {
            if (GetComponent<SpriteRenderer>().flipX == false)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            anim.SetBool("parado", false);
            anim.SetBool("caminando", true);
            rigid.velocity = new Vector2(-velocidad, rigid.velocity.y);

        }

        else if (Input.GetKeyUp(KeyCode.LeftArrow) && ensuelo && !anim.GetBool("patada"))
        {
            anim.SetBool("caminando", false);
            anim.SetBool("parado", true);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("agacharse", true);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("agacharse", false);
        }

        if (Input.GetKey("x") && !disparo && ensuelo)
        {
            tiempodisparo += Time.deltaTime;
            if (tiempodisparo >= 0.25f)
            {
                if (GetComponent<SpriteRenderer>().flipX == false)
                {
                    rigid.velocity = new Vector2(8f, rigid.velocity.y);
                }
                else
                {
                    rigid.velocity = new Vector2(-8f, rigid.velocity.y);
                }

                anim.SetBool("parado", true);
                anim.SetBool("caminando", false);
                anim.SetTrigger("patada");
                disparo = true;
                tiempodisparo = 0f;

            }

        }

        else if (Input.GetKeyUp("x"))
        {
            disparo = false;
        }

        if (!ensuelo)
        {

            anim.SetBool("caer", true);

        }

        if (Input.GetKeyDown("c") && anim.GetBool("parado"))
        {

            rigid.velocity = new Vector2(rigid.velocity.x, 15f);
            anim.SetTrigger("upper");


        }

        else if (Input.GetKeyDown("c") && anim.GetBool("caminando") && ensuelo)
        {

            rigid.velocity = new Vector2(rigid.velocity.x, 15f);
            anim.SetTrigger("upper");

        }





    }


    void bala()
    {

        Instantiate(proyectilprefab, transform.position, Quaternion.identity);

    }



}
