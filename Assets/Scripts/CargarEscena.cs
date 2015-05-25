using UnityEngine;
using System.Collections;

public class CargarEscena : MonoBehaviour {

	public void cargarEscena(string escena){
		Application.LoadLevel (escena);
	}

	public void salir(){
		Application.Quit ();
	}
}
