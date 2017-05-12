using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola : MonoBehaviour {

	public int amplitudX;
	public int amplitudY;
	public int vel = 1;
	Vector3 pos;
	float anterior = 0;
	float sin = 0;
	float cos = 0;
	// Use this for initialization
	void Start () {
		pos = this.transform.position;
		cambiardir ();
	}

	// Update is called once per frame
	void Update () {
		sin = Mathf.Sin (Time.time * vel);
		cos = Mathf.Cos(Time.time * vel);
		this.transform.position = pos + new Vector3(
			amplitudX * sin,
			amplitudY * -Mathf.Abs(cos));
	}

	void cambiardir(){
		int dir = -1;
		if (anterior < sin) {
			dir = 1;
		}

		anterior = sin;

		this.gameObject.transform.localScale = new Vector3 (
			dir * Mathf.Abs(this.gameObject.transform.localScale.x), 
			this.gameObject.transform.localScale.y, 
			this.gameObject.transform.localScale.z);
		
		Invoke ("cambiardir", 0.2f);
	}
}
