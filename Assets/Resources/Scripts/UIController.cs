using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	/* Version Number */
	private static Text versionButtonText, versionButtonGitText;
	private static TextAsset versionFile, versionFileGit;
	private static bool isSet;
	
	void Start () 
	{
	}
	
	public static void UpdateVersions()
	{	
		if(!isSet)
		{
		VersionNumber ();
		VersionNumberGit ();
		isSet = true;
		}
	}

	void Update () {
	
	}

	/* Set the version number from the text file */
	private static void VersionNumber()
	{
		versionButtonText = GameObject.Find ("Version").GetComponent<Text> ();
		versionFile = Resources.Load("VERSION") as TextAsset;
		string versionNumber = versionFile.text;
		versionButtonText.text = "v" + versionNumber;
	}
	
	/* Set the commit number, made by git commits to the VERSION-GIT.txt file*/
	private static void VersionNumberGit()
	{
		versionButtonGitText = GameObject.Find ("VersionGit").GetComponent<Text> ();
		versionFileGit = Resources.Load("VERSION-GIT") as TextAsset;
		string gitNumber = versionFileGit.text;
		/* Remove the new line from the string */
		string gitNumberFixed = gitNumber.Replace("\r", "").Replace("\n", "");
		versionButtonGitText.text = "Commit: " + gitNumberFixed;
	}
}
