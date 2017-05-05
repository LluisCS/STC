using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotasPW : MonoBehaviour {
	public GameObject Botas;
	// Use this for initialization
	void OnEnable () {
		Botas.SetActive (true);
	}
	
	// Update is called once per frame
	void OnDisable () {
		Botas.SetActive (false);
	}

}
