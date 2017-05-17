using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour {

    public GameObject ui_dificultad,
    ui_controles,
    ui_ayuda,
    ui_creditos,
    mov_creditos;
    public MovCreditos movimientoCred;

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
		if (!dificultad) {
			GetComponent<AudioSource> ().Play();
			ui_dificultad.SetActive (true);
		}
		else 
			ui_dificultad.SetActive (false);
		dificultad = !dificultad;
	}
		
	public void MostrarControles(){
		if (!controles) {
			GetComponent<AudioSource> ().Play ();
			ui_controles.SetActive (true);
		}
		else
			ui_controles.SetActive (false);
		controles = !controles;
	}

	public void MostrarAyuda(){
		if (!ayuda) {
			GetComponent<AudioSource> ().Play ();
			ui_ayuda.SetActive (true);
		}
		else
			ui_ayuda.SetActive (false);
		ayuda = !ayuda;
			
	}

	public void MostrarCreditos(){
        if (!creditos)
        {
            GetComponent<AudioSource>().Play();
            ui_creditos.SetActive(true);
            movimientoCred.enabled = true;
            //movimientoCred.Reiniciar();
        }
        else
        {
            ui_creditos.SetActive(false);
            movimientoCred.enabled = false;
        }
        creditos = !creditos;
	}
}
