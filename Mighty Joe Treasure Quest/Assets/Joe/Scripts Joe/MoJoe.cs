using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoJoe : MonoBehaviour {

    public LayerMask sueloLayer;
    public Transform suelocheck;
    public float JumpPower;
    public float velocidad = 4f;
    public bool ensuelo = true;
    float timer = 0.2f;
    float timer2 = 0f;
    public float checkradius = 0.05f;
    public GameObject proyectilprefab;
    public bool disparo = false;

    void bala() {

        Instantiate(proyectilprefab, transform.position, Quaternion.identity);

    }


  
    // Use this for initialization  
    void Start() {

            
    }  
      
   
	// Update is called once per frame
	void Update () {

        if (ensuelo && Input.GetAxis("Jump")>0)
        {
            GetComponent<Animator>().SetBool("joe parado", false);
            GetComponent<Animator>().SetBool("joe saltar", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0f);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPower), ForceMode2D.Impulse);
            ensuelo = false;
                        
        }

        timer2 += 2f *Time.deltaTime;
        if (timer2 >= 0.1f)
        {
            GetComponent<Animator>().SetBool("joe saltar", false);
            GetComponent<Animator>().SetBool("caer", false);
            timer2 = 0;
        }
        

        if (!ensuelo && !GetComponent<Animator>().GetBool("joe saltar"))
        {
            ensuelo = Physics2D.OverlapCircle(suelocheck.position, checkradius, sueloLayer);
            GetComponent<Animator>().SetBool("joe caminando salto", ensuelo);
        }
        
        ensuelo = Physics2D.OverlapCircle(suelocheck.position, checkradius, sueloLayer);
        GetComponent<Animator>().SetBool("joe parado", ensuelo);

        if (Input.GetKey(KeyCode.RightArrow) && !GetComponent<Animator>().GetBool("agacharse") && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Patada"))
        {
            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            GetComponent<Animator>().SetBool("joe parado", false);
            GetComponent<Animator>().SetBool("Joe caminando", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && ensuelo && !GetComponent<Animator>().GetBool("patada"))
        {
            GetComponent<Animator>().SetBool("Joe caminando", false);
            GetComponent<Animator>().SetBool("joe parado", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !GetComponent<Animator>().GetBool("agacharse") && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Patada"))
        {
            if (GetComponent<SpriteRenderer>().flipX == false)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            GetComponent<Animator>().SetBool("joe parado", false);
            GetComponent<Animator>().SetBool("Joe caminando", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && ensuelo && !GetComponent<Animator>().GetBool("patada"))
        {
            GetComponent<Animator>().SetBool("Joe caminando", false);
            GetComponent<Animator>().SetBool("joe parado", true);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Animator>().SetBool("agacharse", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            GetComponent<Animator>().SetBool("agacharse", false);
        }

        if (Input.GetAxis("Fire1") > 0 && !disparo && ensuelo) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                if (GetComponent<SpriteRenderer>().flipX == false)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(8f, GetComponent<Rigidbody2D>().velocity.y);
                }
                else {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-8f, GetComponent<Rigidbody2D>().velocity.y);
                }    
                GetComponent<Animator>().SetBool("joe parado", true);
                GetComponent<Animator>().SetBool("Joe caminando", false);
                GetComponent<Animator>().SetTrigger("patada");
                disparo = true;
                timer = 0.25f;
            }
            
        }

        else if (Input.GetAxisRaw("Fire1") < 1)
        {
            disparo = false;
        }

        if (!ensuelo) {

            GetComponent<Animator>().SetBool("caer", true);

        }
        if (Input.GetKeyDown("c") && GetComponent<Animator>().GetBool("joe parado"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 15f);
            GetComponent<Animator>().SetTrigger("upper");

        }

        else if (Input.GetKeyDown("c") && GetComponent<Animator>().GetBool("Joe caminando") && ensuelo)
        {
            GetComponent<Animator>().SetBool("joe upper caminando", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 15f);
            GetComponent<Animator>().SetTrigger("upper");

        }

  
 

        if (ensuelo) {
            GetComponent<Animator>().SetBool("joe upper caminando", false);

        }


   


    }

   

    
}
