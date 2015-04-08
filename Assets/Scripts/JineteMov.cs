using UnityEngine;
using System.Collections;

/** 
 * Script que determinara el movimiento de la unidad enemiga 
 * 
 * @Author: Alejandro Benadero Peris
 * 
 * */
public class JineteMov : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		float X = 0.05f;
		float Y = 0f;

		//Asignar velocidad en fuerza fija
		//rigidbody2D.AddForce (new Vector2 (10, 5));
		transform.position = new Vector2(transform.position.x + X, transform.position.y);

		//Cambiar la direccion a donde mira el sprite
		transform.localScale = new Vector2 (1, 1);

	}
}
