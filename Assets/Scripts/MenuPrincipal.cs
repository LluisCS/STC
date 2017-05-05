﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour {

	public GameObject ui_dificultad, 
	ui_controles,
	ui_ayuda,
	ui_creditos;

	bool dificultad, controles, ayuda, creditos;

	// Use this for initialization
	void Start () {
		dificultad = controles = ayuda = creditos = false;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			if (dificultad)
				MostrarDificultad ();
			if (ayuda)
				MostrarAyuda ();
			if (creditos)
				MostrarCreditos ();
			if (controles)
				MostrarControles ();
		}
	}

	public void MostrarDificultad(){
		if(!dificultad)
			ui_dificultad.SetActive (true);
		else 
			ui_dificultad.SetActive (false);
		dificultad = !dificultad;
	}
		
	public void MostrarControles(){
		if (!controles)
			ui_controles.SetActive (true);
		else
			ui_controles.SetActive (false);
		controles = !controles;
	}

	public void MostrarAyuda(){
		if (!ayuda)
			ui_ayuda.SetActive (true);
		else
			ui_ayuda.SetActive (false);
		ayuda = !ayuda;
			
	}

	public void MostrarCreditos(){
		if (!creditos)
			ui_creditos.SetActive (true);
		else
			ui_creditos.SetActive (false);
		creditos = !creditos;
	}
}