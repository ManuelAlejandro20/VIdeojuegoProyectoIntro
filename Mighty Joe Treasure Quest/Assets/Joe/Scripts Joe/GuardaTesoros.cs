using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardaTesoros : MonoBehaviour {

    private string[] tesorosposibles = new string[6] { "brazalete", "moneda", "ocarina", "pluma", "tronco", "reloj" };
    private int[] valores = new int[6] { 25000, 35000, 80000, 90000, 300000, 350000 };
    public Canvas[] imagenestesoros;

    int[] pos;
    string[] tesoros;
    int[] precio;
    public static int[] posstatic = new int[3] { -1, -1, -1 };
    public static string[] tesorosstatic = new string[3] {"","","" };
    public static int[] preciostatic = new int[3] {0,0,0};
    public Canvas gameover;

    public Text[] textosvalores;
    public Text[] textosnombres;
    public static int preciototal;

    float[] posx = new float[3] { 250f, 700f, 1125f };
    static int contador = 0;
    bool eliminar = false;
    bool agregar;
    GameObject nombre, val, imagen, cofre;
    Canvas canvas1, canvas2, canvas3;




    void Start() {

        for (int i = 0; i < 6; i++) {
            imagenestesoros[i].GetComponent<Canvas>().enabled = false;

        }

        eliminar = false;
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
                        posstatic[contador] = i; 
                        tesorosstatic[contador] = nombre;
                        preciostatic[contador] = valores[i];
                        contador++;
                    }
                }
                
            }


        }

        eliminarcofre();

        if (contador >= 3) {
            for (int i = 0; i < preciostatic.Length; i++) {
                preciototal += preciostatic[i];
                

            }
        }



        desplegarcanvas();

        if (gameover.GetComponent<Canvas>().enabled) {
            for (int i = 0; i < 3; i++) {
                posstatic[i] = -1;
                tesorosstatic[i] = "";
                preciostatic[i] = 0;
            }

            contador = 0;


        }
    }

    void eliminarcofre()
    {
        int hijos = transform.childCount;
        if (contador >= 3 && !eliminar)
        {

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
                    if (posstatic[i] != -1)
                    {
                        imagenestesoros[posstatic[i]].GetComponent<Canvas>().enabled = false;
                    }
                }

            }
            if (Time.timeScale == 0 )
            {
                Debug.Log("xd");
                for (int i = 0; i < 3; i++)
                {
                    if (posstatic[i] != -1)
                    {
                        imagenestesoros[posstatic[i]].GetComponent<Canvas>().enabled = true;
                        imagen = imagenestesoros[posstatic[i]].transform.Find("RawImage").gameObject;
                        nombre = imagenestesoros[posstatic[i]].transform.Find("Text").gameObject;
                        val = imagenestesoros[posstatic[i]].transform.Find("Valor").gameObject;

                        imagen.GetComponent<RectTransform>().position = new Vector2(posx[i], 420f);
                        nombre.GetComponent<RectTransform>().position = new Vector2(posx[i], 240f);
                        val.GetComponent<RectTransform>().position = new Vector2(posx[i], 210f);
                    }

                }
            }
        }
    }
   
}
