using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmortalidad : MonoBehaviour {

	public float duracion = 7;
	public bool inmortal = false;

	void Start(){//Al activar este componente
			
	}
	void OnTriggerEnter2D(Collider2D other){
		if (inmortal){
			if (other.CompareTag("Obstaculo")||other.CompareTag("Enemigo")){
				Destroy (other.gameObject);
			}
		}
		if(other.CompareTag("PWInmortal")){
			other.gameObject.GetComponent<AudioSource> ().Play ();
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other.gameObject,other.gameObject.GetComponent<AudioSource> ().clip.length);
			inmortal = true;
			Invoke("DesactivarInmortalidad",duracion);	
		}
	}

	void DesactivarInmortalidad(){
		inmortal = false;
	}
}
