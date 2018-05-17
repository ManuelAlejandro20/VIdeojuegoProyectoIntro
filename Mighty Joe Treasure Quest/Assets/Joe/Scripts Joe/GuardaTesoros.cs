using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardaTesoros : MonoBehaviour {

    private string[] tesorosposibles = new string[6] { "brazalete", "moneda", "ocarina", "pluma", "tronco", "reloj" };
    private int[] valores = new int[6] { 25000, 35000, 80000, 90000, 300000, 350000 };
    public string[] tesoros;
    public int[] precio;
    public int contador = 0;
    bool agregar;
    GameObject cofre;

    void Start() {

	}

    // Update is called once per frame
    void Update() {
        cofre = GameObject.FindWithTag("OpenChest");

      
        if (cofre != null && contador <3)
        {
            string nombre = cofre.ToString();
            nombre = nombre.ToLower();
            nombre = nombre.Remove(0, 6);

            Debug.Log("Recogiste " + nombre);

            if (Input.GetKeyDown("x")) {
               
                for (int i = 0; i < 6; i++) {
                    if (tesorosposibles[i].Equals("brazalete")) {
                        tesoros[contador] = nombre;
                        precio[contador] = valores[i];
                        contador++;
                    }
                }
                
            }


        }

        
    }


   
}
