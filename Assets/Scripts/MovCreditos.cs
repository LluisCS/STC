using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCreditos : MonoBehaviour {
    public float velocidad;
    public GameObject creditos;
    float movimiento;
    public float desplazamiento = 0;

    // Update is called once per frame
    void Update () {
		movimiento = velocidad * Time.deltaTime;
		transform.Translate(new Vector3(0, movimiento, 0));
		desplazamiento += movimiento;
		Debug.Log (velocidad + "*" + Time.deltaTime + "=" + movimiento + "(" + desplazamiento + ")");
    }

   /* public void Reiniciar()
    {
        Debug.Log("posicion creditos " + transform.position.y + "Desplazamiento -" + desplazamiento);
        transform.Translate(new Vector3(0, -desplazamiento, 0));
        desplazamiento = 0;
        Debug.Log("Nueva posicion: " + transform.position.y);
    }*/
}
