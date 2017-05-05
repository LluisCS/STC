using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleSalto : MonoBehaviour {

	public int maxSaltos = 2;
	int saltos = 3;
   
	void OnEnable()
    {
		maxSaltos = saltos;
    } 
}
