﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int puntos = 0;
	public static GameManager instance;
	public int bonificacion = 1;
	public float duracionX2 = 7;
	public GameObject camara,fondo1;

	public GameObject ui_pausa;
	public GameObject ui_fin;


	void Start () {
		instance = this;
	}
	//metodo que se llama desde PWx2 que al cabo de duracionX2 ejecuta el metodo desactX2
	public void DesactivarX2(){
		Invoke ("DesactX2",duracionX2);
	}
	//devuelve la bonificación al valor 1 (Desactiva el powerup x2)
	void DesactX2(){
		bonificacion = 1;
	}

	public void Muerto(){
		Time.timeScale = 0;
		MostrarMenuFinPartida ();
	}

	bool paused = false;
	public static float dificultad = 1;

	public void Update(){
		if((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && ui_pausa !=null){
			if (!paused) {
				MostrarMenuPausa ();
			} else {
				OcultarUis ();
				Pausa ();
			}
		}
	}

	public void FixedUpdate(){
		dificultad += 0.004f;
	}

	public void Pausa(){
		if (!paused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
		paused = !paused;
	}

	public void Jugar(int dificultad){
		SceneManager.LoadScene ("juego");
		Time.timeScale = 1;
		GameManager.dificultad = dificultad;
	}

	public void VolverMenuPrincipal(){
		SceneManager.LoadScene ("menu");
	}


	public void MostrarMenuPausa(){
		Pausa ();
		OcultarUis ();
		ui_pausa.SetActive (true);
	}

	public void OcultarMenuPausa(){
		Pausa ();
		OcultarUis ();
	}

	public void MostrarMenuFinPartida(){
		Pausa ();
		OcultarUis ();
		ui_fin.SetActive (true);
	}

	public void OcultarUis(){
		ui_pausa.SetActive (false);
		ui_fin.SetActive (false);
	}

	public void Reload(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		Time.timeScale = 1;
	}
}
