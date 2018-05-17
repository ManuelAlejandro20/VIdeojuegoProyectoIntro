using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tesoro;


 public class Inventario : MonoBehaviour
 {
        private string nombre;
        private Cofre cofre;
        private ListaTesoros tesorosrecogidos;
        Canvas canvas;

        public Inventario(int max) {
               tesorosrecogidos = new ListaTesoros(max);
        }



        void Start()
        {
            canvas = GetComponent<Canvas>();
            cofre = GetComponent<Cofre>();
            canvas.enabled = false;
            Inventario inventario = new Inventario(3);
        }

        void Update()
        {

            if (Input.GetKeyDown("space"))
            {
                if (Time.timeScale == 1)
                {
                    canvas.enabled = true;
                    Time.timeScale = 0;
                }
                else if (Time.timeScale == 0)
                {
                    canvas.enabled = false;
                    Time.timeScale = 1;
                }
            }

            GetComponent<ListaTesoros>().agregartesoro(cofre.getnombre());
         
        
        }
 }