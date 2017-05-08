using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aullar : MonoBehaviour {
	public GameObject aullido;
	public float frecuencia;
	bool cerca = false;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", 0f, frecuencia);
	}
	
	// Update is called once per frame
	void Spawn () {
		GameObject spw = Instantiate (aullido);
		spw.transform.position = this.transform.position;
		GetComponent<AudioSource> ().Play();
	}

}
