using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int puntos = 0;
	public static GameManager instance;
	public int bonificacion = 1;
	public float duracionX2 = 7;
	public GameObject camara;
	public AudioClip muerte, botones;
	public GameObject ui_pausa;
	public GameObject ui_fin;
	public GameObject hud;

	bool muerto = false;

	void Start () {
		instance = this;
		subirVelocidad ();
	}
	//metodo que se llama desde PWx2 que al cabo de duracionX2 ejecuta el metodo desactX2
	public void DesactivarX2(){
		Invoke ("DesactX2",duracionX2);
	}
	//devuelve la bonificación al valor 1 (Desactiva el powerup x2)
	void DesactX2(){
		bonificacion = 1;
		OcultarPowerUp ("pu_doblep");
	}

	public void Muerto(){
		camara.GetComponent<AudioSource> ().Stop ();
		GetComponent<AudioSource> ().Play ();
		Time.timeScale = 0;
		MostrarMenuFinPartida ();
		muerto = true;
	}

	bool paused = false;
	public static float dificultad = 2;
	float velnivel = dificultad;

	public void Update(){
		if((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && ui_pausa !=null && !muerto){
			if (!paused) {
				GetComponent<AudioSource> ().clip = botones;
				MostrarMenuPausa ();
			} else {
				GetComponent<AudioSource> ().clip = muerte;
				OcultarUis ();
				Pausa ();
			}
		}
	}

	public void Pausa(){
		if (!paused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
		paused = !paused;
	}

	public void Jugar(int dificultad){
		GetComponent<AudioSource> ().Play ();
		SceneManager.LoadScene ("juego");
		Time.timeScale = 1;
		GameManager.dificultad = dificultad;
		velnivel = dificultad;
	}

	public void VolverMenuPrincipal(){
		GetComponent<AudioSource> ().Play ();
		SceneManager.LoadScene ("menu");
	}


	public void MostrarMenuPausa(){
		Pausa ();
		OcultarUis ();
		ui_pausa.SetActive (true);
	}

	public void OcultarMenuPausa(){
		GetComponent<AudioSource> ().Play ();
		Pausa ();
		OcultarUis ();
	}

	public void MostrarMenuFinPartida(){
		Pausa ();
		OcultarUis ();
		ui_fin.SetActive (true);
		ui_fin.transform.GetChild (0).gameObject.SetActive (true);
		ui_fin.transform.GetChild (1).gameObject.SetActive (true);
	}

	public void OcultarUis(){
		ui_pausa.SetActive (false);
		ui_fin.SetActive (false);
	}

	public void Reload(){
		GameManager.dificultad = velnivel;
		GetComponent<AudioSource> ().Play ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		Time.timeScale = 1;
	}

	public void MuestraPuntos(){
		GameObject go = hud.transform.GetChild (1).gameObject;
		go.GetComponent<Text>().text = "" + puntos;
	}

	public void MuestraPowerup(Sprite im){
		GameObject go = hud.transform.GetChild (2).gameObject;
		Image i = go.GetComponent<Image>();
		i.sprite = im;
		i.color = Color.white;
	}


	public void OcultarPowerUp(string pu_name){
		GameObject go = hud.transform.GetChild (2).gameObject;
		Image i = go.GetComponent<Image> ();
		if (i.sprite != null) {
			if(i.sprite.name == pu_name){
				i.color = Color.clear;
			}
			if(pu_name == ""){
				i.color = Color.clear;
			}
		}
	}

	public float incrementoVelocidad = 0.001f;
	public float frequenciaIncrementoVel = 1;
	public bool repetirSubirVelocidad = false;
	public void subirVelocidad(){
		if (repetirSubirVelocidad) {
			dificultad += incrementoVelocidad;
			Invoke ("subirVelocidad", frequenciaIncrementoVel);
		}
	}

	public void restauraVelocidad(){
		dificultad = velnivel;
	}

	public void MuestraUIVictoria(){
		ui_fin.SetActive (true);
		ui_fin.transform.GetChild (0).gameObject.SetActive (false);
		ui_fin.transform.GetChild (1).gameObject.SetActive (true);
	}
}
