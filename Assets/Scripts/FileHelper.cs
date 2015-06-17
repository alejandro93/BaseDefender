using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class FileHelper : MonoBehaviour {

	string contenido;
	string victorias;
	string record;
	string [] array;

	int victoriasTemp;
	int recordTemp;

	public Text VictoriasTotales;
	public Text RecordValue;
	

	public void writeVictorias(){
		contenido = File.ReadAllText ("Record.txt");
		victorias = VictoriasTotales.text;

		array = contenido.Split (',');

		record = array [1];
		contenido = victorias + ',' + record;

		File.WriteAllText ("Record.txt", contenido);
	}

	public void writeRecord(){
		victorias = VictoriasTotales.text;

		contenido = File.ReadAllText ("Record.txt");

		array = contenido.Split (',');

		record = array [1];

		recordTemp = int.Parse (record);
		victoriasTemp = int.Parse (victorias);

		if (victoriasTemp > recordTemp) {
			recordTemp = victoriasTemp;

			contenido = "0,"+recordTemp.ToString();
		}
		else
			contenido = "0,"+record;
		File.WriteAllText ("Record.txt", contenido);
	}

	public string readVictorias(){
		try{
			contenido = File.ReadAllText("Record.txt");

			array = contenido.Split (',');

			victorias = array [0];

			return victorias;
		}
		catch(FileNotFoundException) {
			File.WriteAllText("Record.txt", "0,0");

			victorias = "0";
			
			return victorias;
		}
	}

	public string readRecord(){
		try{
			contenido = File.ReadAllText ("Record.txt");
			array = contenido.Split (',');
			
			record = array [1];

			return record;
		}
		catch(FileNotFoundException){
			File.WriteAllText("Record.txt", "0,0");

			record = "0";

			return record;
		}
	}
}
