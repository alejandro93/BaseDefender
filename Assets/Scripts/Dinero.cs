using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dinero : MonoBehaviour {

	public int dinero;
	private string texto;

	public Text Moneda;

	public float tiempo;
	public float ingreso = 0f;

	// Use this for initialization
	void Start () {
		dinero = 0;
	}
	
	// Update is called once per frame
	void Update () {
		tiempo = Time.time;

		texto = Moneda.text;

		if(dinero >= 20) {
			dinero = int.Parse(texto);
			if((tiempo - ingreso) >= 2){
				dinero = dinero+10;
				ingreso = tiempo;
				Moneda.text = dinero.ToString();
			}
		}
		else {
			if((tiempo - ingreso) >= 2){
				dinero = dinero+10;
				ingreso = tiempo;
				Moneda.text = dinero.ToString();
			}
		}
	}
}
