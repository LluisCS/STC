using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamaBehavior : MonoBehaviour {
	public AudioClip c;
	bool noDestruyendo = true;

	void OnEnable () {
		Invoke ("Destruir", 0.7f);
		Invoke ("ActivarCollider",0.1f);
	}
	void Destruir () {
		if(noDestruyendo){
			noDestruyendo = false;
			GetComponent<SpriteRenderer> ().enabled = false;
			GetComponent<LlamaBehavior> ().enabled = false;
			GetComponent<BoxCollider2D> ().enabled = false;
			Gallina.instance.gameObject.GetComponent<AudioSource> ().volume = 0.1f;
			Gallina.instance.gameObject.GetComponent<AudioSource> ().clip = c;
			Gallina.instance.gameObject.GetComponent<AudioSource> ().Play ();
			Invoke ("RetardoDestroy", c.length);
		}
	}
	void RetardoDestroy(){
		Destroy (this.gameObject);
	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Enemigo")||other.gameObject.CompareTag ("Cabeza")) {
			Destroy (other.gameObject);
			Debug.Log ("destruido");
		}
		if (!other.gameObject.GetComponent<Pienso>()) {
			Destruir ();
		}
	}
	void ActivarCollider(){
		gameObject.GetComponent<BoxCollider2D> ().enabled = true;
	}
}
