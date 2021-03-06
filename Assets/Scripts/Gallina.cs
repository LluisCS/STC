﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gallina : MonoBehaviour {

	public static Gallina instance;
	public GameObject camara;
	private float dif;
	AnimacionGallina[] animacionGallina;
	public AnimacionGallina g;
	// Use this for initialization
	void Start(){
		dif = camara.transform.position.x - this.transform.position.x;
		InvokeRepeating ("colocar", 0f, 0.1f);
		animacionGallina = GetComponents<AnimacionGallina> ();
	}
	void Awake () {
		instance = this;
	}
	/*void Update(){
		if(!(GetComponent<Armadura>().enabled&&GetComponent<Lanzallamas>().enabled&&GetComponent<BotasPW>().enabled
			&&GetComponent<Inmortalidad>().inmortal)){
			g.enabled = true;
		}
	}*/
	void colocar(){
		float dif2 = camara.transform.position.x - this.transform.position.x;
		if (dif2 > dif+1)
			this.transform.Translate (0.05f, 0f, 0f);
		else if (dif2 < dif-1)
			this.transform.Translate (-0.05f, 0f, 0f);
	}
	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.CompareTag ("Obstaculo") && (!GetComponent<Armadura> ().enabled) && (!GetComponent<BotasPW> ().enabled))
			{
			Debug.Log ("Has muerto");
			if (coll.gameObject.GetComponent<AudioSource> () != null) {
				coll.gameObject.GetComponent<AudioSource> ().Stop ();
			}
			GameManager.instance.Muerto ();
		}
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Obstaculo") && (!GetComponent<Armadura>().enabled) && 
			(!GetComponent<Inmortalidad>().inmortal)&& (!GetComponent<BotasPW> ().enabled))
        {
            Debug.Log("Has muerto");
            if (other.gameObject.GetComponent<AudioSource>() != null)
                other.gameObject.GetComponent<AudioSource>().Stop();
            GameManager.instance.Muerto();
        }
        if (!GetComponent<Inmortalidad> ().inmortal) {
			if (other.gameObject.CompareTag ("Enemigo") || other.gameObject.CompareTag ("DeadZone")) {
				Debug.Log ("Has muerto");
				if (other.gameObject.GetComponent<AudioSource> () != null) {
					other.gameObject.GetComponent<AudioSource> ().Stop ();
				}
				GameManager.instance.Muerto ();
			}
		}else if(GetComponent<Inmortalidad> ().inmortal){
			if (other.gameObject.CompareTag ("DeadZone")) {
				Debug.Log ("Has muerto");
				GameManager.instance.Muerto ();
			}
		}
		if (other.gameObject.CompareTag("PWLanzallamas")){
			GetComponent<Inmortalidad> ().DesactivarInmortalidad ();
			foreach(AnimacionGallina i in animacionGallina){
				if (i.nombre.Equals ("Fuego")) {
					i.enabled = true;
				} else {
					i.enabled = false;
				}
			}
			GetComponent <Lanzallamas> ().enabled = true;
			GetComponent <TripleSalto> ().enabled = false;
			GetComponent <BotasPW> ().enabled = false;
			GetComponent <Armadura> ().enabled = false;
			other.gameObject.GetComponent<AudioSource> ().Play ();
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other.gameObject,other.gameObject.GetComponent<AudioSource> ().clip.length);
			Sprite s = other.gameObject.GetComponent<SpriteRenderer>().sprite;
			GameManager.instance.MuestraPowerup (s);
		}else if (other.gameObject.CompareTag("PWTripleSalto")){
			GetComponent<Inmortalidad> ().DesactivarInmortalidad ();
			foreach(AnimacionGallina i in animacionGallina){
				if (i.nombre.Equals ("Normal")) {
					i.enabled = true;
				} else {
					i.enabled = false;
				}
			}
			GetComponent <Lanzallamas> ().enabled = false;
			GetComponent <TripleSalto> ().enabled = true;
			GetComponent <BotasPW> ().enabled = false;
			GetComponent <Armadura> ().enabled = false;
			other.gameObject.GetComponent<AudioSource> ().Play ();
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other.gameObject,other.gameObject.GetComponent<AudioSource> ().clip.length);
			Sprite s = other.gameObject.GetComponent<SpriteRenderer>().sprite;
			GameManager.instance.MuestraPowerup (s);
		}else if (other.gameObject.CompareTag("PWBotas")){
			GetComponent<Inmortalidad> ().DesactivarInmortalidad ();
			foreach(AnimacionGallina i in animacionGallina){
				if (i.nombre.Equals ("Botas")) {
					i.enabled = true;
				} else {
					i.enabled = false;
				}
			}
			GetComponent <Lanzallamas> ().enabled = false;
			GetComponent <TripleSalto> ().enabled = false;
			GetComponent <BotasPW> ().enabled = true;
			GetComponent <Armadura> ().enabled = false;
			other.gameObject.GetComponent<AudioSource> ().Play ();
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other.gameObject,other.gameObject.GetComponent<AudioSource> ().clip.length);
			Sprite s = other.gameObject.GetComponent<SpriteRenderer>().sprite;
			GameManager.instance.MuestraPowerup (s);
		}else if (other.gameObject.CompareTag("PWArmadura")){
			GetComponent<Inmortalidad> ().DesactivarInmortalidad ();
			foreach(AnimacionGallina i in animacionGallina){
				if (i.nombre.Equals ("Armadura")) {
					i.enabled = true;
				} else {
					i.enabled = false;
				}
			}
			GetComponent <Lanzallamas> ().enabled = false;
			GetComponent <TripleSalto> ().enabled = false;
			GetComponent <BotasPW> ().enabled = false;
			GetComponent <Armadura> ().enabled = true;
			other.gameObject.GetComponent<AudioSource> ().Play ();
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other.gameObject,other.gameObject.GetComponent<AudioSource> ().clip.length);
			Sprite s = other.gameObject.GetComponent<SpriteRenderer>().sprite;
			GameManager.instance.MuestraPowerup (s);
		} else if (other.gameObject.CompareTag ("PowerUp")) {
			Destroy (other.gameObject,other.gameObject.GetComponent<AudioSource> ().clip.length);
			Sprite s = other.gameObject.GetComponent<SpriteRenderer>().sprite;
			GameManager.instance.MuestraPowerup (s);
		} else if (other.gameObject.CompareTag ("PWInmortal")) {
			Sprite s = other.gameObject.GetComponent<SpriteRenderer> ().sprite;
			GameManager.instance.MuestraPowerup (s);
		}

	}	

	public void ClearImage(){
		GameManager.instance.OcultarPowerUp ("");
	}
}
