using UnityEngine;
using System.Collections;

public class ClonarObjeto : MonoBehaviour {

	public Vector3 posicion = new Vector3 (6.53f, -0.68f, 0f);
	public GameObject Leon;
	public GameObject SoldadoAlly;
	
	public void clonarLeon (GameObject objeto) {
		Instantiate (Leon, posicion, Quaternion.identity);
	}

	public void clonarSoldado (GameObject objeto) {
		Instantiate (SoldadoAlly, posicion, Quaternion.identity);
	}
}
