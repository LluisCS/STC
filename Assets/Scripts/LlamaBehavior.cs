using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamaBehavior : MonoBehaviour {


	void OnEnable () {
		Invoke ("Destruir", 0.7f);
		Invoke ("ActivarCollider",0.1f);
	}
	void Destruir () {
		Destroy (this.gameObject);
	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Enemigo")) {
			Destroy (other.gameObject);
			Debug.Log ("destruido");
		}
		if(!other.gameObject.GetComponent<Pienso>())
			Destruir ();
	}
	void ActivarCollider(){
		gameObject.GetComponent<BoxCollider2D> ().enabled = true;
	}
}
