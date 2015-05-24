using UnityEngine;
using System.Collections;

public class SoldadoMov : MonoBehaviour {

	public float X = 0.01f;
	public float Y = 0f;
	
	public int vida = 50;
	
	private bool recibeDanyo = false;
	
	public int danyo = 0;
	
	public float golpe;
	public float tiempo;
	
	private Animator animator;
	public Rigidbody2D rb;
	
	// Use this for initialization
	void Start () {
		rb.GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		recibeDanyo = false;
		this.gameObject.tag = "SoldadoAlly";

	}
	
	// Update is called once per frame
	void Update () {
		rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		transform.position = new Vector2 (transform.position.x - X, transform.position.y);
		transform.localScale = new Vector3 (-1, 1, 1);
		
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
			if((tiempo-golpe) >= 4){
				destruirObjeto();
			}
		}
	}
	private float resetVelocidad(){
		this.X = 0.01f;
		return X;
	}
	private float detenerVelocidad(){
		this.X = 0f;
		return X;
	}
	void OnCollisionEnter2D(Collision2D target){
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

		default:
//			resetVelocidad();
//			animator.SetInteger("AnimState", 0);
//			danyo = 0;
			break;
		}
	}
	void OnCollisionStay2D(Collision2D target){
		switch(target.gameObject.tag) {
		case "Jinete":
			detenerVelocidad();
			animator.SetInteger("AnimState", 1);
			recibeDanyo = true;
			break;
		case "SoldadoEnemy":
			detenerVelocidad();
			animator.SetInteger("AnimState", 1);
			recibeDanyo = true;
			break;
		default:
			resetVelocidad();
			animator.SetInteger("AnimState", 0);
			break;
		}

	}/*
	void OnTriggerExit2D(Collider2D target){
		animator.SetInteger ("AnimState", 0);
		recibeDanyo = false;
	}
	*/
	void destruirObjeto(){
		transform.position = new Vector2 (transform.position.x - X, transform.position.y);
		gameObject.SetActive(false);
		Destroy (gameObject);
		
	}
}