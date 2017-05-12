using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicionLogic : MonoBehaviour {

	public GameObject fondo1;
	public Sprite snv2,svn3,svnFinal;
	float i;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Transicion")) {
			fondo1.GetComponentInParent<SpriteRenderer> ().sprite = snv2;
			Debug.Log ("Fondo cambiado");
			i = 3.5f;
			Invoke ("RalentizarFondos",6.2f);
		}
		if (other.gameObject.CompareTag ("Transicion2")) {
			fondo1.GetComponentInParent<SpriteRenderer> ().sprite = svn3;
			Debug.Log ("Fondo cambiado");
			i = 1.8f;
			Invoke ("RalentizarFondos",6.2f);
		}
		if (other.gameObject.CompareTag ("Transicion3")) {
			fondo1.GetComponentInParent<SpriteRenderer> ().sprite = svnFinal;
			Debug.Log ("Fondo cambiado");
			i = 3.5f;
			Invoke ("RalentizarFondos",6.2f);
		}
	}
	void RalentizarFondos(){
		fondo1.GetComponentInParent<MovHorizContinuo> ().velX = i;	
	}
}
