using UnityEngine;
using System.Collections;

public class Salto : MonoBehaviour
{
	public AudioClip audioSalto;
    public float fuerza = 5;    //Fuerza que se ejerce sobre le personaje al saltar
	public int maxSaltos = 2;       //El nº máximo de saltos que se pueden dar
	int currentSaltos = 0;   //El nº de saltos que se han dado
    //public bool saltoX3 = false;
  	

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<TripleSalto>().isActiveAndEnabled == true) //Cuando el componente de triple salto está activo
        {
			maxSaltos = GetComponent<TripleSalto> ().maxSaltos;                  //la cantidad máxima de saltos es 3
            //saltoX3 = true;
        }
        else
        {
            maxSaltos = 2;                                                      //si no, es 2
            //saltoX3 = false;
        }

		if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W))
        {
            if (currentSaltos < maxSaltos)                  //Al pulsar "espacio" si no se han dado el máximo de saltos, salta
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerza);
                currentSaltos++;                    //suma uno a los saltos que se han dado
				GetComponent<AudioSource>().volume = 0.5f;
				GetComponent<AudioSource>().clip = audioSalto;
				GetComponent<AudioSource> ().Play ();
            }

        }
    }


    void OnCollisionEnter2D(Collision2D hit)
    {
		if (hit.gameObject.tag == "Suelo"||hit.gameObject.tag == "Muro")                  //Si choca con el suelo los saltos que s ehan dado se pone a 0
            currentSaltos = 0;
    }
}