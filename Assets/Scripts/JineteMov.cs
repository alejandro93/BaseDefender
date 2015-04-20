using UnityEngine;
using System.Collections;

/** 
 * Script que determinara el movimiento de la unidad enemiga 
 * 
 * @Author: Alejandro Benadero Peris
 * 
 * */
public class JineteMov : MonoBehaviour {

	public float X = 0.05f;
	public float Y = 0f;
	public bool hit = false;

	public Animator animator;
	//private Movement movement;

	void Start() {
		//movement.GetComponent<Movement> ();
		animator.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		transform.position = new Vector2 (transform.position.x + X, transform.position.y);

		//Asignar velocidad en fuerza fija
		//rigidbody2D.AddForce (new Vector2 (10, 5));

		if (hit == false) {
			X = 0.02f;
			Y = 0f;
			animator.SetInteger("AnimState", 0);

		} else {
			X = 0f;
			Y = 0f;
			animator.SetInteger("AnimState", 1);
		}

		//Cambiar la direccion a donde mira el sprite
		transform.localScale = new Vector2 (1, 1);

	}
	

	void OnTriggerEnter2D (Collider2D target) {
		if (target.gameObject.tag == "Ally") {
			hit = true;
		}
		if (target.gameObject.tag == "Enemy") {
			hit = false;
		}

	}
	void OnTriggerExit2D () {
		hit = false;
	}
	void OnTriggerStay2D (Collider2D target){
		if (target.gameObject.tag == "Ally") {
			hit = true;
		}
		if (target.gameObject.tag == "Enemy") {
			hit = false;
		}
	}


}
