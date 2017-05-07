using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamaBehavior : MonoBehaviour {
	public AudioClip c;
	bool noDestruyendo = true;

	void OnEnable () {
		Invoke ("Destruir", 0.7f);
		Invoke ("ActivarCollider",0.1f);
		//GetComponent<AudioSource> ().playOnAwake = false;
	}
	void Destruir () {
		if(noDestruyendo){
			noDestruyendo = false;
			GetComponent<SpriteRenderer> ().enabled = false;
			GetComponent<LlamaBehavior> ().enabled = false;
			GetComponent<BoxCollider2D> ().enabled = false;
			GetComponent<AudioSource> ().clip = c;
			GetComponent<AudioSource> ().Play ();
			Invoke ("RetardoDestroy", c.length);
		}
	}
	void RetardoDestroy(){
		Destroy (this.gameObject);
	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Enemigo")) {
			Destroy (other.gameObject);
			Debug.Log ("destruido");
		}
		if (!other.gameObject.GetComponent<Pienso>()&&!other.gameObject.GetComponent<SonidosEnemigos>()) {
			Destruir ();
		}
	}
	void ActivarCollider(){
		gameObject.GetComponent<BoxCollider2D> ().enabled = true;
	}
}
