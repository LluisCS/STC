using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicionLogic : MonoBehaviour {

	public GameObject fondo1;
	public Sprite snv2,svn3;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Transicion")) {
			fondo1.GetComponentInParent<SpriteRenderer> ().sprite = snv2;
			Debug.Log ("Fondo cambiado");
		}
		if (other.gameObject.CompareTag ("Transicion2")) {
			fondo1.GetComponentInParent<SpriteRenderer> ().sprite = svn3;
			Debug.Log ("Fondo cambiado");
		}
	}
}
