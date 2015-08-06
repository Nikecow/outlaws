using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuTogglers : MonoBehaviour {


	//private AudioController au;
	//  private static bool musicOn;
	//  private static bool musicRan;
	//  //private Button mB;

	//  public RawImage yourRawImageTexture;
	//  public Texture2D texture1;
	//  public Texture2D texture2;
	//  private Texture2D yourCurrentTexture;

	public RawImage rawImageTex;
	public Texture2D fullTex1;
	public Texture2D fullTex2;
	private Texture2D currentFullTex;


	//  public static GameObject ga;

	// Use this for initialization
	void Start () 
	{
		Debug.Log("Gestart!");
		//mB = GameObject.Find ("Sound").GetComponent<Button> ();
		//  yourCurrentTexture = texture1;
		FullScreenPress (true);
		
	}

	void Update ()
	{
		//  //Debug.Log ("HasRan: " + PlayerController.HasRan () + "\nmusicRan: " + musicRan);
		//  if (PlayerController.HasRan () && !musicRan) 
		//  {
		//  	au = GameObject.Find ("AudioController(Clone)").GetComponent<AudioController> ();
		//  	MusicPress ();
		//  	musicRan = true;
		//  	//Debug.Log ("running");
		//  }

	}

	void OnGUI ()
	{
		//  yourRawImageTexture.texture = yourCurrentTexture;
		rawImageTex.texture = currentFullTex;

	}
	

	//  public void MusicPress()
	//  {
	//  	if (musicOn) {	// If on turn it off
	//  		AudioController.StopMusic ();
	//  		musicOn = false;
	//  		yourCurrentTexture = texture2;

	//  	} else { // If off turn it on
	//  		AudioController.PlayMusic ("menu");
	//  		musicOn = true;
	//  		yourCurrentTexture = texture1;

	//  	}
	//  }

	public void FullScreenPress(bool firstStart = false) // firstStart is for check if we are in full screen already then change icon.
	{
		if (Screen.fullScreen) 
		{
			if(!firstStart)
			{
				currentFullTex = fullTex1;
				Screen.fullScreen = false;
			} else {
				currentFullTex = fullTex2;
			}
				
		} else {
			if(!firstStart)
			{
				currentFullTex = fullTex2;
				// Switch to the desktop resolution in fullscreen mode.
				Screen.SetResolution (Screen.currentResolution.width, Screen.currentResolution.height, true);
			} else {
				currentFullTex = fullTex1;
			}
		}
	}

}
