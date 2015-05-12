using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	/* Version Number */
	private Text versionButtonText, versionButtonTextGit;
	public TextAsset versionFile, versionFileGit;
	
	void Start () 
	{
		VersionNumber ();
		VersionNumberGit ();
	}

	void Update () {
	
	}

	/* Update the version number from the text file */
	void VersionNumber()
	{
		versionButtonText = GameObject.Find ("Version").GetComponent<Text> ();
		versionFile = Resources.Load("VERSION") as TextAsset;
		string versionNumber = versionFile.text;
		versionButtonText.text = "v " + versionNumber;
	}
	
		void VersionNumberGit()
	{
		versionButtonTextGit = GameObject.Find ("VersionGit").GetComponent<Text> ();
		versionFileGit = Resources.Load("VERSION-GIT") as TextAsset;
		string versionNumber = versionFileGit.text;
		versionButtonTextGit.text = "Commit: " + versionNumber;
	}
}
