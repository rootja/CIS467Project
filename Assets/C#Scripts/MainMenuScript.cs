using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    void MainGUI()
    {
        startButton = startButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();

        startButton.enabled = true;
        quitButton.enabled = true;
    }

    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
