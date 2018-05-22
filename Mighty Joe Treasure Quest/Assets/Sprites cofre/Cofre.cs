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
        /*Gameobject que corresponde al destello que se activará cada vez que se active un cofre*/
        public GameObject destello;
        float tiempo = 0.2f;
        float tiempo2;

     
        void abrircofre()
        {
            /*Si las distancia entre el jugador y el cofre es menor o igual a 1.3 y se presiona la tecla arriba entonces el cofre
             se abrirá y camabiará su tag a "CofreAbierto"*/
            distancia = Vector3.Distance(joe.position, transform.position);
            if (distancia <= 1.3f && !GetComponent<Animator>().GetBool("abierto") && Input.GetKeyDown(KeyCode.UpArrow))
            {

                GetComponent<Animator>().SetBool("abierto", true);
                destello.GetComponent<Animator>().SetBool("brillo", true);
                gameObject.tag = "OpenChest";


            }



        }

        void Start()
        {
        }

        void Update()
        {
            /*Aqui se desactiva el brillo despues de un tiempo determinado*/
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

            /*Cuando se le cambia el tag al cofre quiere decir que ya se ha abierto, lo que permite que se detecte en otros 
             procesos que estan en otros scripts, despues de un tiempo se le vuelve a cambiar su tag al que tenia antes.*/
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