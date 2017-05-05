using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzallamas : MonoBehaviour {
	public GameObject proyectil;
	public GameObject posicion;
	bool active = true;


	// Use this for initialization
	void Activar () {
		active = !active;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q) && active) {
			active = false;
			GameObject proyectilClon = Instantiate (proyectil);
			proyectilClon.GetComponent<MovHorizContinuo>().velX = 2.5f*GetComponentInParent<MovHorizContinuo>().velX;
			proyectilClon.transform.position = posicion.transform.position;
			Invoke("Activar",1f);
		}
	}
}
