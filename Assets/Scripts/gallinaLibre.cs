using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gallinaLibre : MonoBehaviour {
    float distancia;
    float velocidad;
    float posIni;
    // Use this for initialization
    void Start () {
        distancia = Random.Range (5, 15);
        velocidad = Random.Range(5, 25);
        posIni = gameObject.transform.position.x;
       
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(velocidad * Time.deltaTime, 0, 0));
        if ((gameObject.transform.position.x >= posIni + distancia) || (gameObject.transform.position.x <= posIni - distancia))
            gameObject.transform.Rotate(new Vector3(0, gameObject.transform.rotation.y + 180, 0));





    }
}
