using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Transform mainMenu, optionsMenu, controlsScreen, creditsScreen, contactUsScreen; // public transforms for all the canvas screens

    public void LoadScene (string name) // function attached to Main Menu button to return to menu, can choose which scene to load based on name 
    {
        SceneManager.LoadScene(name); // loads scene based on scene's name
    }

    public void QuitGame() // function attached to the Quit Game button
    {
        Application.Quit(); // quits the application if it's an executable version
    }

    public void OptionsMenu(bool clicked) // function attached to the Options menu button with bool attached to see if something has been clicked
    {
        if (clicked == true) // if this button was clicked
        {
            mainMenu.gameObject.SetActive(false); // turn off everything except the options menu screen
            optionsMenu.gameObject.SetActive(true);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(false);
        }
        else // otherwise
        {
            mainMenu.gameObject.SetActive(true); // turn off everything except the main menu screen
            optionsMenu.gameObject.SetActive(false);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(false);
        }
    }

    public void ControlsScreen(bool clicked)
    {
        if (clicked == true) // if this button was clicked
        {
            mainMenu.gameObject.SetActive(false); // turn off everything except the controls screen
            optionsMenu.gameObject.SetActive(false);
            controlsScreen.gameObject.SetActive(true);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(false);
        }
        else // otherwise
        {
            mainMenu.gameObject.SetActive(false); // turn off everything except the options menu screen
            optionsMenu.gameObject.SetActive(true);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(false);
        }
    }

    public void CreditsScreen(bool clicked)
    {
        if (clicked == true) // if this button was clicked
        {
            mainMenu.gameObject.SetActive(false); // turn off everything except the credits screen
            optionsMenu.gameObject.SetActive(false);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(true);
            contactUsScreen.gameObject.SetActive(false);
        }
        else // otherwise
        {
            mainMenu.gameObject.SetActive(false); // turn off everything except the options menu screen
            optionsMenu.gameObject.SetActive(true);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(false);
        }
    }

    public void ContactUsScreen(bool clicked)
    {
        if (clicked == true) // if this button was clicked
        {
            mainMenu.gameObject.SetActive(false); // turn off everything except the contact us screen
            optionsMenu.gameObject.SetActive(false);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(true);
        }
        else // otherwise
        {
            mainMenu.gameObject.SetActive(false); // turn off everything except the options menu screen
            optionsMenu.gameObject.SetActive(true);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(false);
        }
    }
}
