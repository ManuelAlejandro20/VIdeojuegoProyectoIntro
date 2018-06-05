using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiradordeViento : MonoBehaviour {

    public GameObject vientoprefab;
    public GameObject arriba;
    public GameObject abajo;

    GameObject clon;

    bool abajobool;
    bool arribabool;

    RectTransform recttran;
    RectTransform recttranarriba;
    RectTransform recttranabajo;

    void Awake() {

        recttran = GetComponent<RectTransform>();
        recttranarriba = arriba.GetComponent<RectTransform>();
        recttranabajo = abajo.GetComponent<RectTransform>();

    }
	void Start () {

        string nombre = this.name;

        if (nombre.Equals("Lanzaviento arriba"))
        {

            recttran.position = recttranarriba.position;
            abajobool = true;
            arribabool = false;

        }
        else {
            abajobool = false;
            arribabool = true;
        }
        


    }
	
	void Update () {

        if (arribabool)
        {

            recttran.position = Vector3.MoveTowards(recttran.position, recttranarriba.position, 0.1f);
            if (recttran.position == recttranarriba.position)
            {
                abajobool = true;
                arribabool = false;

            }
        }

        else if (abajobool)
        {


            recttran.position = Vector3.MoveTowards(recttran.position, recttranabajo.position, 0.1f);
            if (recttran.position == recttranabajo.position)
            {
                abajobool = false;
                arribabool = true;

            }
        }

        


    }

    void funcionviento()
    {
        if (clon == null)
        {
            clon = Instantiate(vientoprefab, transform.position, Quaternion.identity) as GameObject;
            clon.transform.position = new Vector3(transform.position.x, transform.position.y, -9f);
            clon.GetComponent<Rigidbody2D>().velocity = new Vector2(-40f, GetComponent<Rigidbody2D>().velocity.y);
            Destroy(clon, 1f);
        }

    }
}
