using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosEnemigos : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
	
		if (other.gameObject.GetComponent<Gallina>()){
			GetComponent<AudioSource> ().Play ();
		}


	}

}
