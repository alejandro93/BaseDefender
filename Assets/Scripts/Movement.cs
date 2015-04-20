using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public Vector2 movement = new Vector2 ();
	public bool mover = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		movement.x = 0;
		movement.y = 0;

	}

	void colision (Collision2D target){
		if (target.gameObject.tag == "Enemy") {

		}
	}

}
