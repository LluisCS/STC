using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParonFinal : MonoBehaviour {
	public Camera c;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("DeadZone")){
			c.GetComponent<AudioSource> ().Stop ();
			GameManager.instance.GetComponent<AudioSource> ().Play ();
			GameManager.instance.MuestraUIVictoria ();
			GameManager.instance.Pausa ();
		}
	}
}
