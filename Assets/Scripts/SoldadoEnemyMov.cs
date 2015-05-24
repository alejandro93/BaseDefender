using UnityEngine;
using System.Collections;

public class SoldadoEnemyMov : MonoBehaviour {

	public float X = 0.01f;
	public float Y = 0f;
	
	public int vida = 50;
	
	private bool recibeDanyo = false;
	
	public int danyo = 0;
	
	public float golpe;
	public float tiempo;
	
	private Animator animator;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		recibeDanyo = false;
		this.gameObject.tag = "SoldadoAlly";
		
	}
	
	// Update is called once per frame
	void Update () {
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
		this.X = 0.01f;
		return X;
	}
	private float detenerVelocidad(){
		this.X = 0f;
		return X;
	}
	void OnCollisionEnter2D(Collision2D target){
		switch(target.gameObject.tag) {
		case "Leon":
			detenerVelocidad();
			animator.SetInteger("AnimState", 1);
			danyo = danyo+9;
			recibeDanyo = true;
			golpe = Time.time;
			break;
		case "SoldadoAlly":
			detenerVelocidad();
			animator.SetInteger("AnimState", 1);
			danyo = danyo+4;
			recibeDanyo = true;
			break;
		default:
			resetVelocidad();
			animator.SetInteger("AnimState", 0);
			danyo = 0;
			break;
		}
	}
	void OnCollisionExit2D(Collision2D target){
		animator.SetInteger ("AnimState", 0);
		recibeDanyo = false;
	}
	void destruirObjeto(){
		gameObject.SetActive(false);
		Destroy (gameObject);
		
	}
}