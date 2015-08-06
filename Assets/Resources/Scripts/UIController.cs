using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UIController : MonoBehaviour {

	private static Text text;
	private static TextAsset versionFile;
	private static bool isSet;

	void Start () 
	{
	}
	
	public static void UpdateVersions()
	{	
		if(!isSet)
		{
		VersionNumberUnity ();
		VersionNumber ();
		VersionNumberGit ();
		Changelog ();
		isSet = true;
		}
	}

	
	/* Set the version number of the client and editor */
	private static void VersionNumberUnity()
	{
		text = GameObject.Find ("VersionUnity").GetComponent<Text> ();
		string unityNumber = (Application.unityVersion + " (" + Application.version +")");
		text.text = "Unity: " + unityNumber;
	}

	/* Set the version number from the text file */
	private static void VersionNumber()
	{
		text = GameObject.Find ("Version").GetComponent<Text> ();
		versionFile = Resources.Load("About/VERSION") as TextAsset;
		string versionNumber = versionFile.text;
		text.text = "Version: " + versionNumber;
	}
	
	/* Set the commit number, made by git commits to the VERSION-GIT.txt file*/
	private static void VersionNumberGit()
	{
		text = GameObject.Find ("VersionGit").GetComponent<Text> ();
		versionFile = Resources.Load("About/VERSION-GIT") as TextAsset;
		string gitNumber = versionFile.text;
		/* Remove the new line from the string */
		string gitNumberFixed = gitNumber.Replace("\r", "").Replace("\n", "");
		text.text = "Commit: " + gitNumberFixed;
	}
	
	/* Set the changelog, made by git commits to the CHANGELOG.md5 file*/
	private static void Changelog()
	{
		text = GameObject.Find ("ChangelogText").GetComponent<Text> ();
		versionFile = Resources.Load("About/CHANGELOG") as TextAsset;
		string changeLog = versionFile.text;
		/* Fix the formatting of the changelog output */
		string changeLogFixed = changeLog.Replace("\\t", "\t").Replace("\\n", "\n");
		text.text = changeLogFixed;
	}
	
}
