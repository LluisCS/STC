using UnityEngine;
using System.Collections;

public class Pienso : MonoBehaviour {

	public int Valorpuntos = 1;//Valor cada pienso

	void OnTriggerEnter2D(Collider2D other){
		//Coger Pienso
		if (other.GetComponentInParent <Gallina> ()){//compruebo que se choca con la gallina			
			GameManager.instance.puntos += (Valorpuntos*GameManager.instance.bonificacion);
			Debug.Log (GameManager.instance.puntos + " puntos");
			GameManager.instance.MuestraPuntos ();
			GetComponent<AudioSource> ().Play ();
			GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (gameObject,GetComponent<AudioSource> ().clip.length);
		}
	}
}
