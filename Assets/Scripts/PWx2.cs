using UnityEngine;
using System.Collections;

public class PWx2 : MonoBehaviour {

	public int bonificacion = 2;

	void OnTriggerEnter2D(Collider2D other){
	
		if (other.GetComponentInParent <Gallina> ()){
			GameManager.instance.DesactivarX2();
			GameManager.instance.bonificacion = bonificacion;
			GetComponent<AudioSource> ().Play ();
			GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (gameObject,GetComponent<AudioSource> ().clip.length);
		}	
	}

}
