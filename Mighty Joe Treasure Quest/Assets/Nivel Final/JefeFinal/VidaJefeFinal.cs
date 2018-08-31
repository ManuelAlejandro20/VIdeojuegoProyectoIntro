using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJefeFinal : MonoBehaviour {

    [SerializeField] float vida;
    [SerializeField] float dañohueso;
    [SerializeField] GameObject prefabproyectil;

    [SerializeField] int total;
    [SerializeField] GameObject lanzaproyectiles;

    Rigidbody2D rigid;
    GameObject jugador;
    Animator anim;
    JefeFinal scriptjf;

    bool aux = false;

    public List<GameObject> Proyectil = new List<GameObject>();

    void Awake () {
        jugador = GameObject.FindGameObjectWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scriptjf = GetComponent<JefeFinal>();

        for (int i = 0; i < total; i++)
        {
            GameObject proyectil = Instantiate(prefabproyectil, new Vector3(-1000, -1000, -6f), Quaternion.identity);
            Proyectil.Add(proyectil);
        }


    }
	
	void Update () {
        if (vida < 50f && !aux) {
            scriptjf.setVelocidad(scriptjf.getVelocidad() * 2);
            anim.speed = 3f;
            aux = true;
        }
	}

    public void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            GameObject jugador = col.gameObject;
            VidaJoe scriptvida = jugador.GetComponent<VidaJoe>();
            scriptvida.setvida(scriptvida.getvida() - 30f);

        }
    }

    public void OnTriggerEnter2D(Collider2D colo) {
        if (colo.tag == "Bullet" || colo.tag == "Uppercut")
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            ProyectilComportamiento proycomp = jugador.GetComponent<ProyectilComportamiento>();

            colo.transform.position = new Vector3(-1000, -1000, -6f);
            proycomp.agregar(colo.gameObject);
            Proyectil proyectil = colo.gameObject.GetComponent<Proyectil>();
            vida -= proyectil.getdaño();

            if (vida < 0) {
                Destroy(this.gameObject);
            }

        }
    }

    void UsarProyectil() {
        GameObject proyectil = Proyectil[0];
        proyectil_comportamiento(proyectil);
        Proyectil.RemoveAt(0);
        StartCoroutine(ReusarBala(proyectil));
    }

    IEnumerator ReusarBala(GameObject proyectil) {
        Proyectil scriptproyectil = proyectil.GetComponent<Proyectil>();
        yield return new WaitForSeconds(scriptproyectil.getduracion());
        proyectil.transform.position = new Vector3(-1000, -1000, -6f);
        agregar(proyectil);
    }

    public void agregar(GameObject proyectil)
    {
        Proyectil.Add(proyectil);
    }

    void proyectil_comportamiento(GameObject proyectil)
    {
        Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
        Proyectil scriptproyectil = proyectil.GetComponent<Proyectil>();
        
        if (rigid != null)
        {
            rb.position = lanzaproyectiles.transform.position;
            
        }
        rb.velocity = new Vector2(-scriptproyectil.getvelocidad() - 5f, -scriptproyectil.getvelocidad() + 5f);
        //rb.position = Vector2.MoveTowards(rb.position, jugador.GetComponent<Rigidbody2D>().position, scriptproyectil.getvelocidad());


    }
}
