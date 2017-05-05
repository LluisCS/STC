using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerUp : MonoBehaviour {

	public GameObject[] prefabs;
	// Use this for initialization

	void Start () {
		GameObject c = Instantiate (prefabs [Random.Range (0, prefabs.Length)], transform.position, transform.rotation) as GameObject;
	}

}
