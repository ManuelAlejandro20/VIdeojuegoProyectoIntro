using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 public class Inventario : MonoBehaviour, Tesoros, ListaTesoros
 {

        private ListaTesoros tesorosrecogidos;
        Canvas canvas;

        public Inventario(int max) {
               tesorosrecogidos = new ListaTesoros(max);
        }



        void Start()
        {
            canvas = GetComponent<Canvas>();
            canvas.enabled = false;
            Inventario inventario = new Inventario(3);
        }

        void Update()
        {

            Tesoro tesoro = new Tesoro(cofre.nombre);

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

            tesorosrecogidos.agregartesoro("Xd");
        }
 }