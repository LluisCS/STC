using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallina : MonoBehaviour {

	public static Gallina instance;
	public GameObject camara;
	private float dif;
	// Use this for initialization
	void Start(){
		dif = camara.transform.position.x - this.transform.position.x;
		InvokeRepeating ("colocar", 0f, 0.1f);
	}
	void Awake () {
		instance = this;
	}
	void colocar(){
		float dif2 = camara.transform.position.x - this.transform.position.x;
		if (dif2 > dif+1)
			this.transform.Translate (0.05f, 0f, 0f);
		else if (dif2 < dif-1)
			this.transform.Translate (-0.05f, 0f, 0f);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (!GetComponent<Inmortalidad> ().inmortal){
			if(other.CompareTag("Obstaculo")||other.CompareTag("Enemigo")||other.CompareTag("DeadZone")){
				Debug.Log ("Has muerto");
				GameManager.instance.Muerto ();
			}
		}
		if (other.gameObject.CompareTag("PWLanzallamas")){
			GetComponent <Lanzallamas> ().enabled = true;
			GetComponent <TripleSalto> ().enabled = false;
			GetComponent <BotasPW> ().enabled = false;
			GetComponent <Armadura> ().enabled = false;
			other.gameObject.GetComponent<AudioSource> ().Play ();
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other.gameObject,other.gameObject.GetComponent<AudioSource> ().clip.length);
		}else if (other.gameObject.CompareTag("PWTripleSalto")){
			GetComponent <Lanzallamas> ().enabled = false;
			GetComponent <TripleSalto> ().enabled = true;
			GetComponent <BotasPW> ().enabled = false;
			GetComponent <Armadura> ().enabled = false;
			other.gameObject.GetComponent<AudioSource> ().Play ();
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other.gameObject,other.gameObject.GetComponent<AudioSource> ().clip.length);
		}else if (other.gameObject.CompareTag("PWBotas")){
			GetComponent <Lanzallamas> ().enabled = false;
			GetComponent <TripleSalto> ().enabled = false;
			GetComponent <BotasPW> ().enabled = true;
			GetComponent <Armadura> ().enabled = false;
			other.gameObject.GetComponent<AudioSource> ().Play ();
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other.gameObject,other.gameObject.GetComponent<AudioSource> ().clip.length);
		}else if (other.gameObject.CompareTag("Armadura")){
			GetComponent <Lanzallamas> ().enabled = false;
			GetComponent <TripleSalto> ().enabled = false;
			GetComponent <BotasPW> ().enabled = false;
			GetComponent <Armadura> ().enabled = true;
			other.gameObject.GetComponent<AudioSource> ().Play ();
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other.gameObject,other.gameObject.GetComponent<AudioSource> ().clip.length);
		}
	}	

}
