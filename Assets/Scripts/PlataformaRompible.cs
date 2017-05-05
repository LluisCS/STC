using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaRompible : MonoBehaviour {
	public float t = 0.7f;
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Invoke("destruir", t);
	}

	public void destruir() {
		Destroy(gameObject);
	}
}
