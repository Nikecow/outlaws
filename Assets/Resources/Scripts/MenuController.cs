using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour 
{

	/* Main Menu Objects */
    public Button mainPlayButton;
	public Button mainOptionsButton;
	public Button mainExitButton;
	public static GameObject mainLeaveButton;

	/* Quit Menu Objects */
	public GameObject quitMenu;
	public Button quitYesButton;
	public Button quitNoButton;

	/* Options Menu Objects */
	public GameObject optionsMenu;
	public Button optionsDoneButton;

	/* Variables for the button handlers */
	private GameObject selectedButton;
	public List<GameObject> menuLift = new List<GameObject>();
	private bool firstStart;
	private bool isExitButton;

	/* Add an interface of the audio controller */
	private AudioController ac;
	
	void Start () 
	{
		/* Disable the menus at start, if not already */
		DisableSubMenusAtStart ();

		/* Disable the leave game button at start */
		LeaveGameButtonToggle ();

		ac = GameObject.Find ("AudioController").GetComponent<AudioController> ();
		ac.PlayMusic("Menu");


    }

	void Update ()
	{
		EscapeToggle ();
	}

	/* Play Menu Button */
	
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

			Debug.Log (playText);

	}
    
    /* Exit Menu and leave game Buttons */
	
	public void PressYesExit () 
	{
		Application.Quit ();
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
		if (!mainLeaveButton)
			mainLeaveButton = GameObject.Find ("Leave");

		/* Toggle menu botton, don't disable when still in a game */
		if (mainLeaveButton.activeSelf && !LevelController.isInGame)
			mainLeaveButton.SetActive (false);
		else
			mainLeaveButton.SetActive(true);
		
	}
	
	/* Menu and button handlers  */

	/* ButtonHandler
	 * gets passed the name of the clicked button upon Onclick */
	public void ButtonHandler (string clickedButton = "")
	{
		ButtonDefiner (clickedButton);
		MenuToggler (selectedButton);
	}

	/* ButtonDefiner 
	 * determines what menu should be toggled after a button is clicked and add the menus to the list */
	void ButtonDefiner(string clickedButton = "")
	{

		/* Select the Exit button if required by ToggleQuitMenu */
		if(isExitButton)
			selectedButton = menuLift[1]; 

		/* Select the menus here based on the string passed upon Button onClick() */
			if(firstStart)
			{
			/* Add the menus to a list on firstStart */
			menuLift.Add(optionsMenu);
			menuLift.Add(quitMenu);
			} else {
			switch (clickedButton) 
			{
			/* Select the options menu */
			case "MainOptions":
			case "OptionsDone":
				selectedButton = menuLift[0]; 
				break;
			/* Select the Exit menu */
			case "MainExit":
			case "No":
				selectedButton = menuLift[1]; 
				break;
			}
		}
	}

	/* Menu togglers  */
	
	/* EscapeToggle
	 * if the game is paused, return to game, else open exit menu */
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

	/* Toggle interactable of the main menu */
	void ToggleMainMenuInteractable (bool turnOn = false)
	{
		if (mainPlayButton.IsInteractable() && !turnOn)
		{
			mainPlayButton.interactable = false;
			mainOptionsButton.interactable = false;
			mainExitButton.interactable = false;
		} else {
			mainPlayButton.interactable = true;
			mainOptionsButton.interactable = true;
			mainExitButton.interactable = true;
		}
	}

	void DisableSubMenusAtStart()
	{
		/* First get a list of all the menus at ButtonDefiner 
		* use the bool here instead of at the ButtonDefiner because of max 1 parameter for onClick */
		firstStart = true;
		ButtonDefiner ();
		firstStart = false;
		
		foreach (GameObject menu in menuLift)
		{
			MenuToggler (menu, true);
		}
		
	}
}
