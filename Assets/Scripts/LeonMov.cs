using UnityEngine;
using System.Collections;

public class LeonMov : MonoBehaviour {

	public float X = 0.02f;
	public float Y = 0f;

	public int vida = 100;

	private bool recibeDanyo = false;
	private bool muerto = false;

	public int danyo = 0;

	public float golpe;
	public float tiempo;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		recibeDanyo = false;
		this.gameObject.tag = "Leon";


	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x - X, transform.position.y);
		
		tiempo = Time.time;
		
		if (recibeDanyo == true) {
			
			if((tiempo-golpe) >= 1) {
				vida = vida - danyo;
				golpe = tiempo;
			}
		}
		if (vida <= 0) {
			animator.SetInteger ("AnimState", 2);
			recibeDanyo = false;
			muerto = true;
		}
		if (muerto == true) {
			if((tiempo-golpe) >= 1){
				destruirObjeto();
			}
		}
	}
	private float resetVelocidad(){
		this.X = 0.02f;
		return X;
	}
	private float detenerVelocidad(){
		this.X = 0f;
		return X;
	}
	
	void OnTriggerEnter2D(Collider2D target){
		switch(target.gameObject.tag) {
		case "Jinete":
			detenerVelocidad();
			animator.SetInteger("AnimState", 1);
			danyo = danyo+9;
			recibeDanyo = true;
			golpe = Time.time;
			break;
		case "SoldadoEnemy":
			detenerVelocidad();
			animator.SetInteger("AnimState", 1);
			danyo = danyo+4;
			recibeDanyo = true;
			golpe = Time.time;
			break;
		case "Tower":
			detenerVelocidad();
			animator.SetInteger("AnimState", 1);
			break;
		default:
			break;
		}
	}
	
	void OnTriggerStay2D(Collider2D target){
		if(muerto == false) {
			switch (target.gameObject.tag) {
				case "Jinete":
					detenerVelocidad ();
					animator.SetInteger ("AnimState", 1);
					recibeDanyo = true;
					break;
				case "SoldadoEnemy":
					detenerVelocidad ();
					animator.SetInteger ("AnimState", 1);
					recibeDanyo = true;
					break;
				case "Tower":
					detenerVelocidad();
					animator.SetInteger("AnimState", 1);
					break;
				default:
					break;
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D target){
		switch (target.gameObject.tag) {
			case "Jinete":
				resetVelocidad ();
				animator.SetInteger ("AnimState", 0);
				danyo = danyo - 9;
				recibeDanyo = false;
				break;
			case "SoldadoEnemy":
				resetVelocidad ();
				animator.SetInteger ("AnimState", 0);
				danyo = danyo - 4;
				recibeDanyo = false;
				break;
			default:
				break;
		}
	}
	
	void destruirObjeto(){
		transform.position = new Vector2 (-13, -3);
//		gameObject.SetActive(false);
//		Destroy (gameObject);
		
	}
}
