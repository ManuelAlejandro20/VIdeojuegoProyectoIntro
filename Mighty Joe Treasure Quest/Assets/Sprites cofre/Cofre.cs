using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tesoro
{
    public class Cofre : MonoBehaviour
    {
        public Transform joe;
        [SerializeField] string nombre;
        float distancia;
        public GameObject destello;
        float tiempo = 0.2f;
        float tiempo2;

     
        void abrircofre()
        {

            distancia = Vector3.Distance(joe.position, transform.position);
            if (distancia <= 1.3f && !GetComponent<Animator>().GetBool("abierto") && Input.GetKeyDown(KeyCode.UpArrow))
            {

                GetComponent<Animator>().SetBool("abierto", true);
                destello.GetComponent<Animator>().SetBool("brillo", true);
                gameObject.tag = "OpenChest";

                nombre = gameObject.ToString();
                nombre = nombre.ToLower();
                nombre = nombre.Remove(0, 6);

            }



        }

        void Start()
        {
        }

        void Update()
        {

            abrircofre();
            if (GetComponent<Animator>().GetBool("abierto"))
            {
                tiempo += Time.deltaTime;
                if (tiempo >= 0.4f)
                {

                    destello.GetComponent<Animator>().SetBool("brillo", false);
                    tiempo = 0f;

                }

            }

            if (gameObject.tag.Equals("OpenChest")) {
                tiempo2 += Time.deltaTime;
                if (tiempo2 > 0.05) {
                    gameObject.tag = "Chest";
                    tiempo2 = 0;
                }


            }

        }

    }
}