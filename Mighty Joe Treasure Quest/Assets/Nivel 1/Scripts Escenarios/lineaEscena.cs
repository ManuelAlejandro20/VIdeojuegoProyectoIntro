using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineaEscena : MonoBehaviour {
    public Transform desde;
    public Transform hasta;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDrawGizmosSelected()
    {
        if (desde != null && hasta != null) ;
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(desde.position, hasta.position);
        Gizmos.DrawSphere(desde.position, 1f);
        Gizmos.DrawSphere(hasta.position, 1f);


    }
}
