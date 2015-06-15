using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;


public class LoadRecord : MonoBehaviour {

	public Text RecordValue;
	public FileHelper fileHelper;

	public string record;

	// Use this for initialization
	void Start () {
		record = fileHelper.readRecord ();
		RecordValue.text = record;
	}

}
