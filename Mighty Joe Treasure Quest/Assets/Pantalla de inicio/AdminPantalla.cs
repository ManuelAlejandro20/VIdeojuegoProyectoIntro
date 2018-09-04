using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminPantalla : MonoBehaviour {

    public CanvasGroup[] cglist;
    public FadeOut[] fdlist;

    bool termino;

    void Awake() {
        for (int i = 0; i < 3; i++) {
            fdlist[i].enabled = false;
        }
        fdlist[0].enabled = true;   
    }

    void Update() {
        if (!termino)
        {
            if (cglist[0].alpha == 0)
            {
                fdlist[1].enabled = true;
            }

            if (cglist[1].alpha == 0)
            {
                termino = true;
            }
        }

        else {
            fdlist[0].CortinaEntra();
            if (cglist[0].alpha == 1) {
                cglist[1].alpha = 1;
                fdlist[1].enabled = false;
                fdlist[1].setInicio(true);
                termino = false;
            }
        }

        


       


    }
}
