using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion : MonoBehaviour {

	public string nombre;
	public Sprite[] sprites;
	public float vel;
	int indice;

	// Use this for initialization
	void OnEnable () {
		indice = 0;
		SiguienteFrame ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SiguienteFrame(){
		GetComponent<SpriteRenderer> ().sprite = sprites [indice % sprites.Length];
		indice++;
		if(enabled){
			Invoke ("SiguienteFrame", vel);
		}
	}

}
