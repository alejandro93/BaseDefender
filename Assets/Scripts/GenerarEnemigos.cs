using UnityEngine;
using System.Collections;

public class GenerarEnemigos : MonoBehaviour {

	public GameObject SoldadoEnemy;
	public Vector3 posicion = new Vector3(-6.53f , -0.48f, 0f);
	public int enemyCount = 0;
	public float tiempoDesdeGenerado;
	public float tiempo;

	// Use this for initialization
	void Start () {
		Instantiate (SoldadoEnemy, posicion, Quaternion.identity);
		enemyCount++;
		tiempoDesdeGenerado = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		tiempo = Time.time;
		if ((tiempo - tiempoDesdeGenerado) >= 4) {
			Instantiate (SoldadoEnemy, posicion, Quaternion.identity);
			tiempoDesdeGenerado = tiempo;
		}
	}
}
