using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public Transform pauseMenu; // public transforms for the pause canvas

    public void LoadScene(string name) // function attached to Main Menu button to return to menu, can choose which scene to load based on name 
    {
        SceneManager.LoadScene(name); // loads scene based on scene's name
        Time.timeScale = 1; // turns timescale back to 1 since it was set to 0 when paused
    }

    public void QuitGame() // function attached to the Quit Game button
    {
        Application.Quit(); // quits the application if it's an executable version
    }

    void Update() // this gets updated every frame
    {
        if (Input.GetKeyDown(KeyCode.P)) // if the p key is pressed,
        {
            if (Time.timeScale == 1) // while timescale is currently 1, this would pause game
            {
                Time.timeScale = 0; // set timescale to 0
                pauseMenu.gameObject.SetActive(true); // turn on the pause canvas

                Cursor.lockState = CursorLockMode.None; // unlock the mouse cursor from the screen
                Cursor.visible = true; // set cursor to be visible
            }
            else // otherwise, if timescale was 0, this resumes game
            {
                Time.timeScale = 1; // set timescale to 1
                pauseMenu.gameObject.SetActive(false); // turn the pause canvas off

                Cursor.lockState = CursorLockMode.Locked; // lock the cursor to the screen
                Cursor.visible = false; // hide the cursor
            }
        }
    }
}
