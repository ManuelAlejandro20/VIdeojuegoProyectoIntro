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
    float podersalto = 18f;
    float velocidad = 7f;
    float radiocirculosuelo = 0.05f;
    public float tiempodisparo = 0f;
    float tiemposalto = 0f;
    float vidajoe = 100f;
    int contadorderecha = 0;
    int contadorizquierda = 0;
 
    public LayerMask capasuelo;
    public GameObject proyectilprefab;


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

        if (contadorderecha != 2 && Input.GetKey(KeyCode.RightArrow) && !anim.GetBool("agacharse") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Patada"))
        {
            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            anim.SetFloat("correr", 1f);
            anim.SetBool("parado", false);
            anim.SetBool("caminando", true);
            rigid.velocity = new Vector2(velocidad, rigid.velocity.y);
            contadorizquierda = 0;
        }

        if (contadorderecha !=2 && Input.GetKeyUp(KeyCode.RightArrow) && ensuelo && !anim.GetBool("patada"))
        {
            anim.SetFloat("correr", 0f);
            contadorderecha++;
            anim.SetBool("caminando", false);
            anim.SetBool("parado", true);
        }

        if (contadorizquierda != 2 && Input.GetKey(KeyCode.LeftArrow) && !anim.GetBool("agacharse") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Patada"))
        {

            if (GetComponent<SpriteRenderer>().flipX == false)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            anim.SetFloat("correr", 1f);
            anim.SetBool("parado", false);
            anim.SetBool("caminando", true);
            rigid.velocity = new Vector2(-velocidad, rigid.velocity.y);
            contadorderecha = 0;

        }

        if (contadorizquierda!=2 && Input.GetKeyUp(KeyCode.LeftArrow) && ensuelo && !anim.GetBool("patada"))
        {
            contadorizquierda++;
            anim.SetFloat("correr", 0f);
            anim.SetBool("caminando", false);
            anim.SetBool("parado", true);
        }

        if (contadorderecha >= 2 && Input.GetKey(KeyCode.RightArrow) && !anim.GetBool("agacharse") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Patada"))
        {

            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            anim.SetFloat("correr", 2.0f);
            anim.SetBool("parado", false);
            anim.SetBool("caminando", true);
            rigid.velocity = new Vector2(4 + velocidad, rigid.velocity.y);
            contadorderecha++;
        }

        else if (contadorderecha > 2 && Input.GetKeyUp(KeyCode.RightArrow)) {

            anim.SetFloat("correr", 0f);
            anim.SetBool("caminando", false);
            anim.SetBool("parado", true);
            contadorderecha = 0;

        }

        if (contadorizquierda >= 2 && Input.GetKey(KeyCode.LeftArrow) && !anim.GetBool("agacharse") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Patada"))
        {
            if (GetComponent<SpriteRenderer>().flipX == false)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            anim.SetBool("parado", false);
            anim.SetFloat("correr", 2.0f);
            anim.SetBool("caminando", true);
            rigid.velocity = new Vector2(-4 + -velocidad, rigid.velocity.y);
            contadorizquierda++;

        }

        else if (contadorizquierda > 2 && Input.GetKeyUp(KeyCode.LeftArrow) && ensuelo && !anim.GetBool("patada"))
        {
            anim.SetBool("caminando", false);
            anim.SetFloat("correr", 0f);
            anim.SetBool("parado", true);
            contadorizquierda = 0;
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
