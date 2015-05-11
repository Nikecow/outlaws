using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	/* Version Number */
	public Text versionButtonText;
	public TextAsset versionFile;
	
	void Start () 
	{
		VersionNumber ();
	}

	void Update () {
	
	}

	/* Update the version number from the text file */
	void VersionNumber()
	{
		versionButtonText = GameObject.Find ("Version").GetComponent<Text> ();
		versionFile = Resources.Load("VERSION") as TextAsset;
		string versionNumber = versionFile.text;
		Debug.Log ("Version: " + versionNumber);
		versionButtonText.text = versionNumber;
	}
}
