﻿using UnityEngine;
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
		this.gameObject.tag = "SoldadoEnemy";
		
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
		gameObject.SetActive(false);
		Destroy (gameObject);
		
	}
}