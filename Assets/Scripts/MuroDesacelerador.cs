﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroDesacelerador : MonoBehaviour {
	public bool restauraVel = false;

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Gallina")) {
			GameManager.instance.repetirSubirVelocidad = false;
			if (restauraVel)
				GameManager.instance.restauraVelocidad ();
		}
	}
}
