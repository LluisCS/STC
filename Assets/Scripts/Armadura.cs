using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadura : MonoBehaviour {
	AnimacionGallina[] animacionGallina;
	public int golpes= 3;
	bool anim;
	void OnEnable () {
		golpes = 3;
		anim = true;
	}
	void Start(){
		animacionGallina = GetComponents<AnimacionGallina> ();
	}
	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.CompareTag ("Muro")&&enabled) {
			Destroy (other.gameObject);
			golpes--;
		}else if (other.gameObject.CompareTag ("Obstaculo")&&enabled) {
			Destroy (other.gameObject);
			golpes--;
		}
		if (golpes == 0&&anim) {
			foreach(AnimacionGallina i in animacionGallina){
				if (i.nombre.Equals ("Normal")) {
					i.enabled = true;
					anim = false;
				} else {
					i.enabled = false;
				}
			}
			enabled = false;

		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
