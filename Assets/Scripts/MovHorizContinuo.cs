using UnityEngine;
using System.Collections;

public class MovHorizContinuo : MonoBehaviour {
	
	public float velX = 3;
	public float direccion = 1;//+derecha -izquierda


	// Update is called once per frame
	void Update () {		
		Movimiento();
	}

	void Movimiento(){		
		transform.Translate (new Vector3(direccion*GameManager.dificultad*velX*Time.deltaTime,0,0));
	}
}
