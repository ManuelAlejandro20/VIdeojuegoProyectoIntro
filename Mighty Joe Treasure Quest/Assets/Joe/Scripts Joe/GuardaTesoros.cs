using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardaTesoros : MonoBehaviour {

    private string[] tesorosposibles = new string[6] { "brazalete", "moneda", "ocarina", "pluma", "tronco", "reloj" };
    private int[] valores = new int[6] { 25000, 35000, 80000, 90000, 300000, 350000 };
    public Canvas[] imagenestesoros;

    public int[] pos;
    public string[] tesoros;
    public int[] precio;
    public int preciototal;

    int contador = 0;
    bool eliminar = false;
    bool agregar;
    GameObject imagen;
    GameObject cofre;
    Canvas canvas1, canvas2, canvas3;

    void Start() {

        for (int i = 0; i < 6; i++) {
            imagenestesoros[i].GetComponent<Canvas>().enabled = false;

        }

	}

    void Update() {


        cofre = GameObject.FindWithTag("OpenChest");
     
        

      
        if (cofre != null && contador <3)
        {
            string nombre = cofre.ToString();
            nombre = nombre.ToLower();
            nombre = nombre.Remove(0, 6);
            string mensaje = " (unityengine.gameobject)";
            nombre = nombre.Replace(mensaje, "");
            Debug.Log("Recogiste " + nombre);

            if (Input.GetKeyDown("x")) {
               
                for (int i = 0; i < 6; i++) {
                    if (tesorosposibles[i].Equals(nombre)) {
                        pos[contador] = i; 
                        tesoros[contador] = nombre;
                        precio[contador] = valores[i];
                        contador++;
                    }
                }
                
            }


        }

        eliminarcofre();

        if (contador >= 3) {
            for (int i = 0; i < precio.Length; i++) {
                preciototal += precio[i];
                

            }
            contador = 0;
        }

        desplegarcanvas();

    }

    void eliminarcofre() {
        int hijos = transform.childCount;
        if (contador >= 3 && !eliminar) {

            for (int i = hijos - 1; i > -1; i--)
            {
                GameObject.Destroy(transform.GetChild(i).gameObject);
            }

            eliminar = true;

        }

       

    }


    void desplegarcanvas() {
        
        if (Input.GetKeyDown("space"))
        {
            if (Time.timeScale == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    imagenestesoros[pos[i]].GetComponent<Canvas>().enabled = false;

                }

            }
            else if (Time.timeScale == 0)
            {
               
                for (int i = 0; i < 3; i++)
                {
                    imagenestesoros[pos[i]].GetComponent<Canvas>().enabled = true;
                    /*imagen = GameObject.FindWithTag("Imagen");
                    float x = -175.7f;
                    float y = 34.3f;
                    imagen.GetComponent<RectTransform>().position = new Vector2(x,y);*/



                }
            }
        }
    }
   
}
