using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiradordeViento : MonoBehaviour {

    public GameObject vientoprefab;
    public GameObject arriba;
    public GameObject abajo;

    bool abajobool = true;
    bool arribabool = false;

    RectTransform recttran;
    RectTransform recttranarriba;
    RectTransform recttranabajo;

    void Awake() {

        recttran = GetComponent<RectTransform>();
        recttranarriba = arriba.GetComponent<RectTransform>();
        recttranabajo = abajo.GetComponent<RectTransform>();

    }
	void Start () {

        recttran.position = recttranarriba.position;


    }
	
	void Update () {

        if (arribabool)
        {

            recttran.position = Vector3.MoveTowards(recttran.position, recttranarriba.position, 0.5f);
            if (recttran.position == recttranarriba.position)
            {
                abajobool = true;
                arribabool = false;

            }
        }

        else if (abajobool)
        {


            recttran.position = Vector3.MoveTowards(recttran.position, recttranabajo.position, 0.5f);
            if (recttran.position == recttranabajo.position)
            {
                abajobool = false;
                arribabool = true;

            }
        }

        


    }

    void funcionviento()
    {
        Instantiate(vientoprefab, transform.position, Quaternion.identity);
    }
}
