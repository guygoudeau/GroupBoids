using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public Transform mainMenu, optionsMenu, controlsScreen, creditsScreen, contactUsScreen; // public transforms for all the canvas screens
    public GameObject audioSource; // public gameobject for the audio source aka background music
    bool soundToggle = true; // bool to determine if sound should be playing

    public void LoadScene(string name) // function attached to Main Menu button to return to menu, can choose which scene to load based on name 
    {
        SceneManager.LoadScene(name); // loads scene based on scene's name
    }
    
    public void Mute() // function attached to mute button 
    {
        soundToggle = !soundToggle; // soundtoggle equals notSoundToggle
        if (soundToggle) // if sound toggle is true
        {
            audioSource.SetActive(true); // set the audio source to inactive
        }
        else // otherwise
        {
            audioSource.SetActive(false); // it's active
        }
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