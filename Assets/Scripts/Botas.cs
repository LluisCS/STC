using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Cabeza")) {
			other.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 5.0f);
			Destroy (other.transform.parent.gameObject);

		}
	}
}
