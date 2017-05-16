using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaOso : MonoBehaviour {

	public Sprite cerrada;
	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("Gallina")){
			GetComponent<SpriteRenderer> ().sprite = cerrada;
		}
	}
}
