using UnityEngine;
using System.Collections;

/** 
 * Script que determinara el movimiento de la unidad enemiga 
 * 
 * @Author: Alejandro Benadero Peris
 * 
 * */
public class JineteMov : MonoBehaviour {

	public float X = 0.02f;
	public float Y = 0f;
	
	public int vida = 100;
	
	private bool recibeDanyo = false;
	
	public int danyo = 0;
	
	public float golpe;
	public float tiempo;
		
	public Rigidbody2D rb;
	private Animator animator;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		animator = GetComponent<Animator> ();
		recibeDanyo = false;
		this.gameObject.tag = "Jinete";
		
		
	}
	
	// Update is called once per frame
	void Update () {
		rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		transform.position = new Vector2 (transform.position.x + X, transform.position.y);
		
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
		case "Leon":
			detenerVelocidad();
			animator.SetInteger("AnimState", 1);
			danyo = danyo+10;
			recibeDanyo = true;
			golpe = Time.time;
			break;
		case "SoldadoAlly":
			detenerVelocidad();
			animator.SetInteger("AnimState", 1);
			danyo = danyo+5;
			recibeDanyo = true;
			golpe = Time.time;
			break;
		default:
			break;
		}
	}
	
	void OnTriggerStay2D(Collider2D target){
		switch (target.gameObject.tag) {
		case "Leon":
			detenerVelocidad ();
			animator.SetInteger ("AnimState", 1);
			recibeDanyo = true;
			break;
		case "SoldadoAlly":
			detenerVelocidad ();
			animator.SetInteger ("AnimState", 1);
			recibeDanyo = true;
			break;
		default:
			break;
		}
	}
	
	void OnTriggerExit2D(Collider2D target){
		switch (target.gameObject.tag) {
		case "Leon":
			resetVelocidad ();
			animator.SetInteger ("AnimState", 0);
			danyo = danyo - 10;
			recibeDanyo = false;
			break;
		case "SoldadoAlly":
			resetVelocidad ();
			animator.SetInteger ("AnimState", 0);
			danyo = danyo - 5;
			recibeDanyo = false;
			break;
		default:
			break;
		}
	}
	void destruirObjeto(){
		transform.position = new Vector2 (-13, -3);
		gameObject.SetActive(false);
		Destroy (gameObject);
		
	}
}
