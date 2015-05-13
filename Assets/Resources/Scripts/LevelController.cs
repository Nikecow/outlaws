using UnityEngine;

public class LevelController : MonoBehaviour {

	/* The parent game objects for static reference */
	public static GameObject menu;
	public static GameObject world;

	/* The vars which track if the user is in game or in menu, and if he has launched at least once */
	public static bool hasLaunched;

	public static bool isInGame;
	public static bool isPaused;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () 
	{
		EscapeToggle ();
	}

	public static void PressPlay()
	{
		if (!hasLaunched) 
		{
			menu = GameObject.Find ("SceneMenu");
			Application.LoadLevelAdditive (1);
			hasLaunched = true;
			isPaused = true;
        }

		/* Only select the world if it's null */
		if(!world)
			world = GameObject.Find ("SceneWorld");

		/* If in menu, turn menu off and turn world on upon play click */ 
		if (!isInGame) {
			menu.SetActive (false);
			if(world)
				world.SetActive (true);
		} else {
			menu.SetActive (true);
			world.SetActive (false);
		}
		LevelController.ResumeToggler ();

	}


	void EscapeToggle()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (LevelController.isInGame) 
			{		
				MenuController.LeaveGameButtonToggle();
                LevelController.PressPlay ();
            }
        }
    }
	
	public static void ResumeToggler ()
	{
		if (isInGame)
			isInGame = false;
		else
			isInGame = true;
	}
	
}