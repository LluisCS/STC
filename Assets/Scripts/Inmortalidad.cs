using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmortalidad : MonoBehaviour {

	public float duracion = 7;
	public bool inmortal = false;
	AnimacionGallina[] animacionGallina;
	public AnimacionGallina g ;

	void Start(){//Al activar este componente
		animacionGallina = GetComponents<AnimacionGallina> ();
	}
	void OnTriggerEnter2D(Collider2D other){
		if (inmortal){
			if (other.CompareTag("Enemigo")){
				Destroy (other.gameObject);
			}
		}
		if(other.CompareTag("PWInmortal")){
			foreach(AnimacionGallina i in animacionGallina){
				if (i.nombre.Equals ("Inmortal")) {
					i.enabled = true;

				} else {
					i.enabled = false;
				}
			}
			GetComponent <Lanzallamas> ().enabled = false;
			GetComponent <TripleSalto> ().enabled = false;
			GetComponent <BotasPW> ().enabled = false;
			GetComponent <Armadura> ().enabled = false;
			other.gameObject.GetComponent<AudioSource> ().Play ();
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other.gameObject,other.gameObject.GetComponent<AudioSource> ().clip.length);
			inmortal = true;
			Invoke("DesactivarInmortalidad",duracion);	
		}
	}
	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.CompareTag("Muro")){
			Destroy (coll.gameObject);
		}
	}
	public void DesactivarInmortalidad(){
		int numDesact = 0;
		inmortal = false;
		foreach(AnimacionGallina i in animacionGallina){
			if (i.nombre.Equals ("Inmortal")) {
				i.enabled = false;
			} 
			if (i.enabled == false) {
				numDesact++;
			}
			if (numDesact == 5) {
				g.enabled = true;
			}
		}//Fin for
	}
}
