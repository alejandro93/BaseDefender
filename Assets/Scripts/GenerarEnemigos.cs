using UnityEngine;
using System.Collections;

public class GenerarEnemigos : MonoBehaviour {

	public GameObject SoldadoEnemy;
	public GameObject Jinete;

	public int enemyCount = 0;
	public float ultimoGenerado;
	public float tiempo;

	public float random;
	// Use this for initialization
	void Start () {
		Instantiate (SoldadoEnemy, new Vector3(-7.3f , -0.5f, 0f), Quaternion.identity);
		enemyCount++;
		ultimoGenerado = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		tiempo = Time.time;
		if (enemyCount > 2) {
			random = Random.Range(0f, 1f);

			if ((tiempo - ultimoGenerado) >= 5) {
				if(random > 0.7f){
					Instantiate (Jinete, new Vector3(-7f , -1f, 0f), Quaternion.identity);
					ultimoGenerado = tiempo;
					enemyCount++;
				}
				else{
					Instantiate (SoldadoEnemy, new Vector3(-7.3f , -0.5f, 0f), Quaternion.identity);
					ultimoGenerado = tiempo;
					enemyCount++;
				}
			}
		}
		else 
		if ((tiempo - ultimoGenerado) >= 7) {
			Instantiate (SoldadoEnemy, new Vector3(-7.3f , -0.5f, 0f), Quaternion.identity);
			ultimoGenerado = tiempo;
			enemyCount++;
		}
	}
}
