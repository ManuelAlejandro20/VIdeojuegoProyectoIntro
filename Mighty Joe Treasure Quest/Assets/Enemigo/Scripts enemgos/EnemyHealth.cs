using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float vidaenemigo = 100f;


    public void OnTriggerEnter2D(Collider2D col) {

        if (col.tag == "Bullet") {

            vidaenemigo -= Patada.daño;
            if (vidaenemigo <= 0)
            {
                Destroy(gameObject);
            }
            
        }

    }
}
