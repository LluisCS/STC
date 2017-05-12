using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParonFinal : MonoBehaviour {
	public Gallina g;
	public Camera c;
	public GameObject fondos;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("DeadZone")){
			g.GetComponent<MovHorizContinuo> ().enabled = false;
			c.GetComponent<MovHorizContinuo> ().enabled = false;
			fondos.GetComponent<MovHorizContinuo> ().enabled = false;
		}
	}
}
