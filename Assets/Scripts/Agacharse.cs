using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agacharse : MonoBehaviour {
    	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {  
			GetComponent<BoxCollider2D> ().offset = new Vector2 (0f,-0.5f);
			GetComponent<BoxCollider2D> ().size = new Vector2 (3.52f,1.5f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) {  
			GetComponent<BoxCollider2D> ().offset = new Vector2 (0f,0f);
			GetComponent<BoxCollider2D> ().size = new Vector2 (3.52f,2.83f);
       }
	}
}
