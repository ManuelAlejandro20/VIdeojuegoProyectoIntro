using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

    public bool inicio = true;

    void Update()
    {
        if (inicio)
        {
            StartCoroutine(transicion(1));

        }
    }


    IEnumerator cortina() {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        while (cg.alpha > 0) {
            cg.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        inicio = false;
        cg.interactable = false;
        yield return null;
    }

    IEnumerator cortinaentra() {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        while (cg.alpha < 1)
        {
            cg.alpha += Time.deltaTime * 2;
            yield return null;
        }
        inicio = true;
        cg.interactable = false;
        yield return null;
    }


    public IEnumerator transicion(int num) {
        yield return new WaitForSeconds(10f);
        if (num == 1)
        {
            StartCoroutine(cortina());
        }
        else {
            StartCoroutine(cortinaentra());
        }
        
    }

    public void CortinaEntra() {
        StartCoroutine(transicion(0));
    }

    public void setInicio(bool nuevacond) {
        this.inicio = nuevacond;
    }

}
