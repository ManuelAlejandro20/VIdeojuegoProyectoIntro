using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Tesoros : MonoBehaviour
    {
        private string[] tesoros = new string[6] { "brazalete", "moneda", "ocarina", "pluma", "tronco", "reloj" };
        private int[] valores = new int[6] { 25000, 35000, 80000, 90000, 300000, 350000 };
        private string nombre;
        private int valor;

        public Tesoros(string nombre) {
            for (int i = 0; i < 6; i++) {
                if (tesoros[i].Equals(nombre)) {
                    this.nombre = tesoros[i];
                    this.valor = valores[i];
                }
            }
        }
        
        
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public class ListaTesoros : MonoBehaviour
    {
        
        private Tesoros[] tes;
        private int canttesoros;

        public ListaTesoros(int max)
        {
            tes = new Tesoros[max];
        }

        public void agregartesoro(string nombre) {
            Tesoros tesoro = new Tesoros(nombre);

        }



    }
