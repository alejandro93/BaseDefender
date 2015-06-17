using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnableButton : MonoBehaviour {

	public GameObject infanteria;
	public GameObject caballeria;

	public GameObject Leon;
	public GameObject SoldadoAlly;

	public Text Moneda;

	private string texto;
	public int dinero;


	// Use this for initialization
	void Start () {

		infanteria = GameObject.Find("Infanteria");
		infanteria.GetComponent<Button> ().interactable = false;

		caballeria = GameObject.Find("Caballeria");
		caballeria.GetComponent<Button> ().interactable = false;

	}
	
	// Update is called once per frame
	void Update () {

		texto = Moneda.text;
		//Debug.Log ("Contiene " + texto);

		dinero = int.Parse(texto);

		if (dinero <= 10) {
			infanteria.GetComponent<Button> ().interactable = false;
		} else {
			infanteria.GetComponent<Button> ().interactable = true;
		}

		if (dinero <= 30) {
			caballeria.GetComponent<Button> ().interactable = false;
		} else {
			caballeria.GetComponent<Button> ().interactable = true;
		}

	}
	public void clonarLeon (GameObject objeto) {
		Instantiate (Leon, new Vector3 (7f, -1f, 0f), Quaternion.identity);
		dinero = dinero-40;
		Moneda.text = dinero.ToString();
	}
	
	public void clonarSoldado (GameObject objeto) {
		Instantiate (SoldadoAlly, new Vector3 (7.5f, -1f, 0f), Quaternion.identity);
		dinero = dinero - 20;
		Moneda.text = dinero.ToString();
	}
}
