using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Tesoro
{
    public class ListaTesoros : MonoBehaviour
    {

        private Tesoros[] tes;
        private int canttesoros;

        public ListaTesoros(int max)
        {
            tes = new Tesoros[max];
        }

        public void agregartesoro(string nombre)
        {
            Debug.Log(nombre);
            Tesoros tesoro = new Tesoros(nombre);
            tes[canttesoros] = tesoro;
            canttesoros++;

        }



    }
}