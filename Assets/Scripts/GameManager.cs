using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int puntos = 0;
	public static GameManager instance;
	public int bonificacion = 1;
	public float duracionX2 = 7;
	public GameObject camara,fondo1;


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
		camara.GetComponent<AudioSource> ().Stop ();
		GetComponent<AudioSource> ().Play ();
		Gallina.instance.GetComponent<MovHorizContinuo> ().enabled = false;
		camara.GetComponent<MovHorizContinuo> ().enabled = false;
		fondo1.GetComponent<MovHorizContinuo> ().enabled = false;
	}
}
