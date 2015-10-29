using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {

    public bool isPaused = false;
    public static bool isKeysEnabled = true;
    public GameObject PauseMenu;
    /*public Button resumeButton;
    public Button optionsButton;
    public Button exitButton;
    public Button quitButton;*/

    //Test and verify if some of this code is even needed. 
    //(Like resetting variables when exiting to main menu or quitting.)


	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
        /*resumeButton = resumeButton.GetComponent<Button>();
        optionsButton = optionsButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();*/
		Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ScanForKeyStroke();
	}

    void ScanForKeyStroke()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                isPaused = true;
                ToggleAudio();
                Time.timeScale = 0;
                LockInput(true);
                /*resumeButton.enabled = true;
                optionsButton.enabled = true;
                exitButton.enabled = true;
                quitButton.enabled = true;*/
                PauseMenu.SetActive(true);
            }
            else
            {
                isPaused = false;
                ToggleAudio();
                Time.timeScale = 1;
                LockInput(false);
                /*resumeButton.enabled = false;
                optionsButton.enabled = false;
                exitButton.enabled = false;
                quitButton.enabled = false;*/
                PauseMenu.SetActive(false);
            }
        }
    }

    void ToggleAudio()
    {
        if(isPaused == true)
        {
            foreach(var audio in GetComponents<AudioSource>())
            {
                audio.Pause();
            }
        }
        else
        {
            foreach (var audio in GetComponents<AudioSource>())
            {
                audio.UnPause();
            }
        }
    }

    void LockInput(bool setInputLock)
    {
        if(setInputLock)
        {
            isKeysEnabled = false;
        }
        else
        {
            isKeysEnabled = true;
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        ToggleAudio();
        Time.timeScale = 1;
        LockInput(false);
        /*resumeButton.enabled = false;
        optionsButton.enabled = false;
        exitButton.enabled = false;
        quitButton.enabled = false;*/
        PauseMenu.SetActive(false);
    }

    public void OptionsMenu()
    {
        //Fill in logic for new options menu!
    }

    public void ExitToMainMenu()
    {
        isPaused = false;
        ToggleAudio();
        LockInput(false);
        /*resumeButton.enabled = false;
        optionsButton.enabled = false;
        exitButton.enabled = false;
        quitButton.enabled = false;
        PauseMenu.SetActive(false);*/
        Application.LoadLevel(0);
    }

    public void QuitGame()
    {
        isPaused = false;
        ToggleAudio();
        PauseMenu.SetActive(false);
        Application.Quit();
    }
	
}