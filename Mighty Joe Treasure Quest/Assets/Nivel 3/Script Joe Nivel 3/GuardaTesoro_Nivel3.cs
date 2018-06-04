using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardaTesoro_Nivel3 : MonoBehaviour {

    /*Todos los nombres de los tesoros que se pueden obtener*/
    private string[] tesorosposibles = new string[6] { "brazalete", "moneda", "ocarina", "pluma", "tronco", "reloj" };
    private int[] valores = new int[6] { 25000, 35000, 80000, 90000, 300000, 350000 };
    /*Arreglo que se llenará desde el inspector contiene todas las imagenes */
    public Canvas[] imagenestesoros;

    /*Arreglos estaticos para que no se borren los datos al avanzar de escena, cuando se recolecte un tesoro su posición (que está
     en "tesorosposibles") se almacenará en "posstatic",  "tesorosstatic" almacenará los nombres y "preciosstatic" guardará su 
     precio*/
    public static int[] posstatic = new int[3] { -1, -1, -1 };
    public static string[] tesorosstatic = new string[3] { "", "", "" };
    public static int[] preciostatic = new int[3] { 0, 0, 0 };
    /*Pantalla de gameover*/
    public Canvas gameover;

    /*Suma de todos los valores de los tesoros*/
    public static int preciototal;

    /*Contador estatico que nos dice cuantos tesoros llevamos almacenados*/
    static int contador = 0;
    /*Booleanos auxiliares*/
    bool eliminar = false;
    bool agregar;

    GameObject imagen, cofre;

    public Image[] slots;

    RectTransform posimagen;
    RectTransform posnombre;
    RectTransform posval;


    void Start()
    {

        /*Todas las imagenes de los tesoros cargadas en el inspector se van a desactivar*/
        for (int i = 0; i < 6; i++)
        {
            imagenestesoros[i].GetComponent<Canvas>().enabled = false;

        }

        eliminar = false;
    }

    void Update()
    {

        /*Se obtiene un gameobject con el tag "Cofreabierto", este es un cofre que ya ha a sido abierto por el jugador*/
        cofre = GameObject.FindWithTag("OpenChest");



        /*Si el gameobject no es nulo eso quiere decir que se ya se ha abierto un cofre, contador menor a 3 se refiere a que 
         si hemos recolectado menos de 3 tesoros*/
        if (cofre != null && contador < 3)
        {
            /*Se obtiene el nombre del cofre abierto y se eliminan algunos strings que sobran*/
            string nombre = cofre.ToString();
            nombre = nombre.ToLower();
            nombre = nombre.Remove(0, 6);
            string mensaje = " (unityengine.gameobject)";
            nombre = nombre.Replace(mensaje, "");

            /*Para este punto el juego ya está pausado y mostrando la imagen del tesoro obtenido junto con su valor y descripción
             cuando se presione Z se volverá a la normalidad y se procederá a buscar el nombre del objeto obtenido en el arreglo
             "tesorosposibles" agregando su posicion, nombre y precio a los arreglos correspondientes*/

            if (Input.GetKeyDown("x"))
            {

                for (int i = 0; i < 6; i++)
                {
                    if (tesorosposibles[i].Equals(nombre))
                    {
                        posstatic[contador] = i;
                        tesorosstatic[contador] = nombre;
                        preciostatic[contador] = valores[i];
                        contador++;
                    }
                }

            }


        }

        eliminarcofre();

        /*Si el contador es mayor o igual a 3 quiere decir que ya recolectamos todos los objetos, por lo que se procedera a sumar
         todos sus valores*/
        if (contador >= 3)
        {
            for (int i = 0; i < preciostatic.Length; i++)
            {
                preciototal += preciostatic[i];


            }
        }



        desplegarcanvas();
        /*Si la pantalla de gameover está activa quiere decir que el jugador ya ha perdido por lo que las listas se limpian y 
         el contador vuelve a 0*/
        if (gameover.GetComponent<Canvas>().enabled)
        {
            for (int i = 0; i < 3; i++)
            {
                posstatic[i] = -1;
                tesorosstatic[i] = "";
                preciostatic[i] = 0;
            }

            contador = 0;


        }
    }
    /*Metodo que verifica que ya hemos recogido 3 tesoros si es asi se eliminan todos los cofres restantes para que el jugador
     ya no pueda recolectar más*/
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

    /*Si se apreta la tecla espacio se van a desplegar las imagenes de los tesoros recogidos hasta el momento*/
    void desplegarcanvas()
    {

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
            if (Time.timeScale == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (posstatic[i] != -1)
                    {
                        imagenestesoros[posstatic[i]].GetComponent<Canvas>().enabled = true;
                        imagen = imagenestesoros[posstatic[i]].transform.Find("RawImage").gameObject;

                        imagen.GetComponent<RectTransform>().position = new Vector2(slots[i].GetComponent<RectTransform>().position.x, slots[i].GetComponent<RectTransform>().position.y);

                    }

                }
            }
        }
    }

    public bool verificartesoro(string nombre)
    {
        for (int i = 0; i < 3; i++)
        {
            if (tesorosstatic[i].Equals(nombre))
            {
                return true;
            }
        }
        return false;
    }
}
