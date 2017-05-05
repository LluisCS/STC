using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadura : MonoBehaviour {

	public int golpes= 3;
	void OnEnable () {
		golpes = 3;
	}
	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.CompareTag ("Muro")&&enabled) {
			Destroy (other.gameObject);
			golpes--;
		}
		if (golpes == 0)
			enabled = false;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
