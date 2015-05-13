using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour 
{

	/* Main Menu objects and buttons */
    public Button mainPlayButton;
	public Button mainLeaveButton;
	public Button mainOptionsButton;
	public Button mainExitButton;
	public static GameObject mainLeaveButtonObject;

	/* Quit Menu objects and buttons */
	public GameObject quitMenu;
	public Button quitYesButton;
	public Button quitNoButton;

	/* Options Menu objects and buttons */
	public GameObject optionsMenu;
	public Button optionsDoneButton;
	
	/* About Menu objects and buttons */
	public Button aboutButton;
	public GameObject aboutMenu;
	public Button aboutDoneButton;

	/* Variables for the button handlers */
	private GameObject selectedButton;
	private List<GameObject> menuList = new List<GameObject>();
	private bool firstStart;
	private bool isExitButton;

	/* Add an interface of the audio controller */
	private AudioController ac;
	private	bool hasPlayed;
	
	void Start () 
	{
		/* Disable the menus at start, if not already */
		DisableSubMenusAtStart ();

		/* Disable the leave game button at start */
		LeaveGameButtonToggle ();
		
		/* Refer the AudioController Object */
		ac = GameObject.Find("AudioController").GetComponent<AudioController>();
    }

	void Update ()
	{
		EscapeToggle ();
		PlayOnStartMenuMusic();
	}
	
	void PlayOnStartMenuMusic()
	{
		if(!hasPlayed)
		{
		 ac.PlaySound("menu");
		 hasPlayed = true;
		}
	}

	/* Main Menu Play Button */
	
	public void PressPlay () 
	{
		/* Only change the resume button once per session */
		if (!LevelController.isPaused) 
		{
			ResumeTextToggler ();
		}
		LevelController.PressPlay ();
	}

	/* Change the play button to resume or vice versa */
	public void ResumeTextToggler ()
	{
			Text playText = mainPlayButton.GetComponent<Text> ();
			if (playText.text == "play")
				playText.text = "Resume";
			else
				playText.text = "play";
	}
    
    /* Exit Menu and leave game Buttons */
	
	public void PressYesExit () 
	{
		Application.Quit ();
	}
	
	/* About Menu Button
	 * Add this so the text of the about menu can be updated firt before opening
	 */
	public void PressAbout (string clickedButton) 
	{
		ButtonHandler(clickedButton);
		UIController.UpdateVersions();
	}
	
	/* Simulate a click on the exit button */
	void ToggleQuitMenu ()
	{
		isExitButton = true;
		ButtonHandler ();
		isExitButton = false;
	}

	public void LeaveGame ()
	{
		LevelController.hasLaunched = false;
		LevelController.isPaused = false;
		GameObject.Destroy (LevelController.world);

		LeaveGameButtonToggle ();
		ResumeTextToggler ();

	}

	public static void LeaveGameButtonToggle()
	{
		/* Only select if the object is null */
		if (!mainLeaveButtonObject)
			mainLeaveButtonObject = GameObject.Find ("Leave");

		/* Toggle menu botton, don't disable when still in a game */
		if (mainLeaveButtonObject.activeSelf && !LevelController.isInGame)
			mainLeaveButtonObject.SetActive (false);
		else
			mainLeaveButtonObject.SetActive(true);
		
	}
	
	/* Menu and button handlers  */

	/* ButtonHandler
	 * gets passed the name of the clicked button upon Onclick 
	 */
	public void ButtonHandler (string clickedButton = "")
	{
		ButtonDefiner (clickedButton);
		MenuToggler (selectedButton);
	}

	/* ButtonDefiner 
	 * determines what menu should be toggled after a button is clicked and add the menus to the list 
	 * Add the objects for menu toggling here!
	 */
	void ButtonDefiner(string clickedButton = "")
	{

		/* Select the Exit button if required by ToggleQuitMenu */
		if(isExitButton)
			selectedButton = menuList[1]; 

		/* Select the menus here based on the string passed upon Button onClick() */
			if(firstStart)
			{
			/* Add the menus to a list on firstStart */
			menuList.Add(optionsMenu);
			menuList.Add(quitMenu);
			menuList.Add(aboutMenu);
			} else {
			switch (clickedButton) 
			{
			/* Select the options menu */
			case "MainOptions":
			case "OptionsDone":
				selectedButton = menuList[0]; 
				break;
			/* Select the Exit menu */
			case "MainExit":
			case "No":
				selectedButton = menuList[1]; 
				break;
				
			/* Select the About menu */
			case "About":
			case "AboutDone":
				selectedButton = menuList[2]; 
				break;
			}
		}
	}

	/* Menu and button togglers */
	
	/* EscapeToggle
	 * if the game is paused, return to game, else open exit menu 
	 */
	void EscapeToggle()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (!LevelController.isPaused) 
			{
				ToggleQuitMenu ();
			} else {
				PressPlay ();
			}
			
		}
	}

	/* Toggle the selected menu */
	void MenuToggler (GameObject button, bool firstStart = false)
	{
		if (!button.activeSelf && !firstStart) 
		{
			button.SetActive (true);
			ToggleMainMenuInteractable ();
		} else {
			ToggleMainMenuInteractable (true);
			button.SetActive (false);
		}
	}

	/* Toggle interactable of the main menu 
	 * Add buttons which need to be toggled here
 	 */
	void ToggleMainMenuInteractable (bool turnOn = false)
	{
		if (mainPlayButton.IsInteractable() && !turnOn)
		{
			mainPlayButton.interactable = false;
			mainLeaveButton.interactable = false;
			mainOptionsButton.interactable = false;
			mainExitButton.interactable = false;
		} else {
			mainPlayButton.interactable = true;
			mainLeaveButton.interactable = true;
			mainOptionsButton.interactable = true;
			mainExitButton.interactable = true;
		}
	}

	void DisableSubMenusAtStart()
	{
		/* First get a list of all the menus at ButtonDefiner 
		* use the bool here instead of at the ButtonDefiner because of max 1 parameter for onClick 
		*/
		firstStart = true;
		ButtonDefiner ();
		firstStart = false;
		
		foreach (GameObject menu in menuList)
		{
			MenuToggler (menu, true);
		}
		
	}
}
