using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScript : MonoBehaviour {
	
    public Button quitButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MainGUI()
    {
        quitButton = quitButton.GetComponent<Button>();
        quitButton.enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
