using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AullidoBehavior : MonoBehaviour {

	AnimacionGallina[] animacionGallina;
	public Gallina g;
	// Use this for initialization
	void Start () {
		Invoke ("Agrandar", 0.03f);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x > 7f)
			Destroy (gameObject);
	}
	void OnTriggerEnter2D( Collider2D other){
		if (other.gameObject.CompareTag ("Gallina")) {
			other.gameObject.GetComponent <BotasPW>().enabled = false;
			other.gameObject.GetComponent <Lanzallamas>().enabled = false;
			GameManager.instance.bonificacion = 1;
			other.gameObject.GetComponent <TripleSalto>().enabled = false;
			other.gameObject.GetComponent <Armadura>().enabled = false;
			animacionGallina = other.GetComponents<AnimacionGallina> ();
			foreach(AnimacionGallina i in animacionGallina){
				if (i.nombre.Equals ("Normal")) {
					i.enabled = true;
				} else if (!i.nombre.Equals ("Inmortal")) {
					i.enabled = false;
				}
			}
		}
	}

	void Agrandar(){
		transform.localScale = new Vector3 (transform.localScale.x + 0.2f, transform.localScale.y + 0.2f, transform.localScale.z);
		Invoke("Agrandar", 0.05f);
	}
}

