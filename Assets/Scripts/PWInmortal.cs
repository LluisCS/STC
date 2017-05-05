using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWInmortal : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag("Gallina")){
			Gallina.instance.gameObject.GetComponentInChildren<Inmortalidad> ().inmortal = true;
			Destroy (gameObject);
		}	
	}
}
