using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroAcelerador : MonoBehaviour {

	public float incremento = 0.0001f;
	public float velocidad = 1f;
	
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag("Gallina")) {
			GameManager.instance.frequenciaIncrementoVel = velocidad;
			GameManager.instance.repetirSubirVelocidad = true;
			GameManager.instance.incrementoVelocidad = incremento;
			GameManager.instance.subirVelocidad ();
		}
	}

}
