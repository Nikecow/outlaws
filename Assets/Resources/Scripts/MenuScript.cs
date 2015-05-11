using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


public class MenuScript : MonoBehaviour 
{

	/* Main Menu Objects */
    public Button mainPlayButton;
	public Button mainOptionsButton;
	public Button mainExitButton;

	/* Quit Menu Objects */
	public GameObject quitMenu;
	public Button quitExitButton;
	public Button quitNoButton;

	/* Options Menu Objects */
	public GameObject optionsMenu;
	public Button optionsDoneButton;

	/* Variables for the button handlers */
	private GameObject selectedButton;
	public List<GameObject> menuLift = new List<GameObject>();
	private bool firstStart;
    

	void Start () 
	{
		/* Disable the menus at start, if not already */
		DisableSubMenusAtStart ();
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

	/* Main Menu Buttons */

	public void PressStart () 
	{
		Application.LoadLevel (1);
	}

    
    /* Exit Menu Buttons */
	
	public void PressYesExit () 
	{
		Application.Quit ();
	}

	/* Menu and button handlers and togglers */

	/* ButtonDefiner 
	 * determines what menu should be toggled after a button is clicked and add the menus to the list */
	void ButtonDefiner(string clickedButton = "")
	{
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

	/* ButtonHandler
	 * gets passed the name of the clicked button upon Onclick */
	public void ButtonHandler (string clickedButton)
	{
		ButtonDefiner (clickedButton);
		MenuToggler (selectedButton);
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
}
