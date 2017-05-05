using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerroBehavior : MonoBehaviour {
	float startPos, LimD2, LimI2;
	public float Vel, LimD, LimI;

	// Use this for initialization
	void Start () {
		startPos = this.transform.position.x;
		LimD2 = startPos + LimD;
		LimI2 = startPos - LimI;
	}
	
	// Update is called once per frame
	void Update () {
		if (LimI2 <= LimD2) {
			this.transform.Translate (Vel * Time.deltaTime, 0, 0);
		}
		if (this.transform.position.x >= LimD2 || this.transform.position.x <= LimI2) {
			Vel = -Vel;
			this.gameObject.transform.localScale = new Vector3 (
				this.gameObject.transform.localScale.x * -1,
				this.gameObject.transform.localScale.y,
				this.gameObject.transform.localScale.z
			);
		}
	}
}
