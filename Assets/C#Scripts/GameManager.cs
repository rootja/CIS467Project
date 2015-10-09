using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public GameObject cynthia;
    public BoardManager boardScript;
    private int level = 1;

    //public static GameManager instance = null;

	// Use this for initialization
	void Start () {

    //    if (instance == null)
    //        instance = this;
    //    else if (instance != this)
    //        Destroy(gameObject);

    //    DontDestroyOnLoad(gameObject);

		Instantiate (player);
		Instantiate (cynthia);

        boardScript = GetComponent<BoardManager>();
        Init();
	}

    //Called each time a level was loaded
    void OnLevelWasLoaded(int index)
    {
        //Add one to our level number.
        level++;
        //Call Init to initialize the level.
        Init();
    }

    void Init()
    {
        boardScript.LevelSelector(level);
    }
	
	// Update is called once per frame
	void Update () {

	}
}
