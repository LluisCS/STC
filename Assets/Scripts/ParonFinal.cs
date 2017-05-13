using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParonFinal : MonoBehaviour {
	public Gallina g;
	public Camera c;
	public GameObject fondos;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Gallina")){
			GameManager.instance.MuestraUIVictoria ();
			GameManager.instance.Pausa ();
		}
	}
}
