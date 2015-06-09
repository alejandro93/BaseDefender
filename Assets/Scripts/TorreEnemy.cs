using UnityEngine;
using System.Collections;

public class TorreEnemy : MonoBehaviour {

	public int vida = 1000;
	public int danyo = 0;

	private bool recibeDanyo = false;

	public float golpe;
	public float tiempo;

	// Use this for initialization
	void Start () {
		recibeDanyo = false;
		this.gameObject.tag = "Tower";
	}
	
	// Update is called once per frame
	void Update () {
		tiempo = Time.time;
		
		if (vida <= 0) {
			Application.LoadLevel("Juego");
		}
		else
		if (recibeDanyo == true) {
			if((tiempo-golpe) >= 1) {
				vida = vida - danyo;
				golpe = tiempo;
			}
		}

	}

	void OnTriggerEnter2D (Collider2D target) {
		switch(target.gameObject.tag) {
			case "Leon":;
				danyo = danyo+10;
				recibeDanyo = true;
				golpe = Time.time;
				break;
			case "SoldadoAlly":
				danyo = danyo+5;
				recibeDanyo = true;
				golpe = Time.time;
				break;
			default:
				break;
		}
	}
	
	void OnTriggerStay2D (Collider2D target) {
		switch (target.gameObject.tag) {
			case "Leon":
				recibeDanyo = true;
				break;
			case "SoldadoAlly":
				recibeDanyo = true;
				break;
			default:
				break;
		}
	}
	
	void OnTriggerExitD (Collider2D target) {
		switch (target.gameObject.tag) {
			case "Leon":
				danyo = danyo - 10;
				recibeDanyo = false;
				break;
			case "SoldadoAlly":
				danyo = danyo - 5;
				recibeDanyo = false;
				break;
			default:
				break;
		}
	}
}
