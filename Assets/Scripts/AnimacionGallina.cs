﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionGallina : MonoBehaviour {
	
	public string nombre;
	public Sprite[] sprites;
	public Sprite[] spritesAgach;
	public float vel;
	int indice;
	bool noAgachado = true,agachado = false;

		// Use this for initialization
		
	void OnEnable () {
		indice = 0;
		SiguienteFrame ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftShift)) {  
			noAgachado = false;
			agachado = true;
			GetComponent<BoxCollider2D> ().offset = new Vector2 (0f,-0.5f);
			GetComponent<BoxCollider2D> ().size = new Vector2 (3.518393f,1.25f);
			SiguienteFrameAgachado ();

		}else if (Input.GetKeyUp(KeyCode.LeftShift)) {  
			noAgachado = true;
			agachado = false;
			SiguienteFrame ();
			GetComponent<BoxCollider2D> ().offset = new Vector2 (0f,0f);
			GetComponent<BoxCollider2D> ().size = new Vector2 (3.518393f,2.825212f);
		}
	}

		
	void SiguienteFrame(){
		GetComponent<SpriteRenderer> ().sprite = sprites [indice % sprites.Length];
		indice++;
		if(enabled&&noAgachado){
			Invoke ("SiguienteFrame", vel);
		}
	}
	void SiguienteFrameAgachado(){
		GetComponent<SpriteRenderer> ().sprite = spritesAgach [indice % spritesAgach.Length];
		indice++;
		if(enabled&&agachado){
			Invoke ("SiguienteFrameAgachado", vel);
		}
	}

}
