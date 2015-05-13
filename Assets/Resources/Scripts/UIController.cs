using UnityEngine;
using UnityEngine.UI;

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

	/* Set the version number from the text file */
	void VersionNumber()
	{
		versionButtonText = GameObject.Find ("Version").GetComponent<Text> ();
		versionFile = Resources.Load("VERSION") as TextAsset;
		string versionNumber = versionFile.text;
		versionButtonText.text = "v" + versionNumber;
	}
	
	/* Set the commit number, made by git commits to the VERSION-GIT.txt file*/
		void VersionNumberGit()
	{
		versionButtonTextGit = GameObject.Find ("VersionGit").GetComponent<Text> ();
		versionFileGit = Resources.Load("VERSION-GIT") as TextAsset;
		string gitNumber = versionFileGit.text;
		/* Remove the new line from the string */
		string gitNumberFixed = gitNumber.Replace("\r", "").Replace("\n", "");
		versionButtonTextGit.text = "Commit: " + gitNumberFixed;
	}
}
