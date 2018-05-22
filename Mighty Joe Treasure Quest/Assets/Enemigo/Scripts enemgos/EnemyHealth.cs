using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    /*Todos los enemigos empiezan con la misma vida */
    public float vidaenemigo = 100f;

    /*Se detecta cuando el enemigo recibe un golpe o el Uppercut*/
    public void OnTriggerEnter2D(Collider2D col) {

        if (col.tag == "Bullet" || col.tag == "Uppercut") {

            vidaenemigo -= Patada.daño;
            if (vidaenemigo <= 0)
            {
                Destroy(gameObject);
            }
            
        }

    }
}
