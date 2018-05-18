using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJoe : MonoBehaviour {

    public float vidajoe = 100f;


    public void OnCollisionEnter(Collision col)
    {

        if (col.collider.tag == "Enemy")
        {

            vidajoe -= 30f;
            if (vidajoe <= 0)
            {
                Destroy(gameObject);
            }

        }

    }
}
