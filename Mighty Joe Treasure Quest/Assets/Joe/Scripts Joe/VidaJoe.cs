using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaJoe : MonoBehaviour {

    public static float vidajoe = 100f;
    float vidajoe2 = 100f;


	AudioSource au;
	AudioSource[] aus;
	public AudioClip[] efectos;
    public Canvas terminojuego;
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

	Canvas canvasgameover;

    int escenaactual;

    /*GameObject NS;
    NivelSuperado scriptNS;
    Canvas canvasNS;
    int escenaactual;
    float tiempocanvas = 0;
    bool pasonivel = false;*/

    bool musica_gameover;
	bool boolaux = true;
    void Awake() {

        jugador = GameObject.FindGameObjectWithTag("Player").transform;
		au = GetComponent<AudioSource> ();
		aus = GetComponents<AudioSource> ();
		rigid = jugador.GetComponent<Rigidbody2D>();
        box = jugador.GetComponent<BoxCollider2D>();
        script = jugador.GetComponent<MoJoe>();
        sprite = jugador.GetComponent<SpriteRenderer>();
        anim = jugador.GetComponent<Animator>();
        textovidas.text = "x " + (vidas - 1);
		canvasgameover = terminojuego.GetComponent<Canvas> ();
        escenaactual = SceneManager.GetActiveScene().buildIndex;
        /*if (SceneManager.GetActiveScene().buildIndex == 3) {
            NS = GameObject.Find("NivelSuperado");
            scriptNS = NS.GetComponent<NivelSuperado>();
            canvasNS = scriptNS.GetComponent<Canvas>();
        }*/
        
    }

    void Update() {
        //si es que joe llega a perder una vida, se reiniciara el juego con el descuento de una vida
		if (vidajoe <= 0 && !anim.GetBool("muertosuelo")) {
            anim.SetTrigger("muerto");
            anim.SetBool("muertosuelo",true);
			au.clip = efectos [1];
			au.Play ();
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
			

        //si joe pierde todas las vidas se devolvera la pantalla inicial de juego
		if (anim.GetBool("muertosuelo")) {
            tiempo += Time.deltaTime;
            if (tiempo >= 2.5f) {
                if (vidas == 0)
                {
                    musica_gameover = true;
                    Time.timeScale = 0;
                    canvasgameover.enabled = true;
                    if (Input.GetKeyDown("x"))
                    {

                        vidajoe = vidajoe2;
                        vidas = 3;
                        canvasgameover.enabled = false;
                        Time.timeScale = 1;
                        SceneManager.LoadScene(0);

                    }
                }
                else
                {

                    vidajoe = vidajoe2;
                    if (escenaactual >= 1 && escenaactual <= 3)
                    {
                        SceneManager.LoadScene(1);
                    }
                    else if (escenaactual >= 4 && escenaactual <= 9)
                    {
                        SceneManager.LoadScene(4);
                    }
                    else if (escenaactual >= 10 && escenaactual <= 15) {
                        SceneManager.LoadScene(10);
                    }
                    else if (escenaactual >= 16 && escenaactual <= 17) {
                        SceneManager.LoadScene(16);
                    }


                       
                    

                }
            }

        }

		if (musica_gameover && boolaux) {
			aus [1].Play ();
			boolaux = false;

		}

        /*if (canvasNS.enabled) {
            pasonivel = true;
            DontDestroyOnLoad(this);
            
        }

        if (pasonivel) {
            tiempocanvas += Time.deltaTime;
            if (tiempocanvas > 1f) {
                Destroy(this);
            }
        }*/


    }

	void FixedUpdate(){
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        //si es que el enemigo ejecuta daño a Joe a este se le reducira la vida
        if (col.gameObject.tag == "Enemy" && vidajoe > 0)
        {
            enemigo = col.gameObject;
            scriptenemigo = enemigo.GetComponent<Movimientoenemigo>();
			au.clip = efectos [0];
			au.Play ();
            anim.SetTrigger("daño");
            if (sprite.flipX == false)
            {
                rigid.AddForce(new Vector2(-16f, 6f), ForceMode2D.Impulse);

            }
            else {

                rigid.AddForce(new Vector2(16f, 6f), ForceMode2D.Impulse);
            }

			if (scriptenemigo != null) { 
				vidajoe -= scriptenemigo.getdaño ();
			}
        }
        //la barra de vida sera reducida segun el daño
        else if (col.gameObject.tag == "Barrera" && vidajoe > 0) {
            barrera = col.gameObject;
            barreramuerte = barrera.GetComponent<Barrera>();
            vidajoe -= barreramuerte.getdaño();
        }
        
    }

    //se retorna la vida de joe
    public float getvida() {
        return vidajoe;
    }

	public int getvida1up(){
		return vidas;
		
	}

	public void setvida(float vidanueva){
		vidajoe = vidanueva;
	}

	public void setvida1up(int numvidas){
		
		vidas = numvidas;

	}
}
