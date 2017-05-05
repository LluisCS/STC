using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoLogic : MonoBehaviour {
	public GameObject fin,inicio;
	float x;

	void Start(){
		x =  transform.position.x - inicio.gameObject.transform.position.x;
	}
	// Use this for initialization

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("DeadZone")) {
			transform.position = new Vector3 ((fin.gameObject.transform.position.x + x),
				fin.gameObject.transform.position.y, fin.gameObject.transform.position.z);
		}
	}
}
