using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola : MonoBehaviour {

	public int amplitudX;
	public int amplitudY;
	public int vel = 1;
	Vector3 pos;
	bool recorrido = true;

	// Use this for initialization
	void Start () {
		pos = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		float sin = Mathf.Sin (Time.time * vel);
		this.transform.position = pos + new Vector3(
			amplitudX * sin,
			amplitudY * -Mathf.Abs(Mathf.Cos(Time.time * vel)));

		if (Mathf.Abs(sin) <= 0.1f)
			recorrido = true;

		if (recorrido && Mathf.Abs(sin) >= (0.99f)) {
			this.gameObject.transform.localScale = new Vector3 (-this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
			recorrido = false;
		}
	}
}
