using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public Transform pauseMenu, playerUI; // public transforms for the pause canvas and the health bars and weapon text
    public GameObject audioSource; // pulic audio source, aka background music
    bool soundToggle = true; // bool to determine if sound should be playing

    public void LoadScene(string name) // function attached to Main Menu button to return to menu, can choose which scene to load based on name 
    {
        SceneManager.LoadScene(name); // loads scene based on scene's name
        Time.timeScale = 1; // turns timescale back to 1 since it was set to 0 when paused
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

    void Update() // this gets updated every frame
    {
        if (Input.GetKeyDown(KeyCode.P)) // if the p key is pressed,
        {
            if (Time.timeScale == 1) // while timescale is currently 1, this would pause game
            {
                Time.timeScale = 0; // set timescale to 0
                pauseMenu.gameObject.SetActive(true); // turn on the pause canvas
                playerUI.gameObject.SetActive(false); // turn off the player's UI
            }
            else // otherwise, if timescale was 0, this resumes game
            {
                Time.timeScale = 1; // set timescale to 1
                pauseMenu.gameObject.SetActive(false); // turn the pause canvas off
                playerUI.gameObject.SetActive(true); // turn the player's UI back on
            }
        }
    }
}