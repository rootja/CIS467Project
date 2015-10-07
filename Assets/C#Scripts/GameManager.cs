using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public GameObject cynthia;
    public BoardManager boardScript;
    private int level = 10;

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
        boardScript.LevelSelector(level);
	} 
	
	// Update is called once per frame
	void Update () {

	}
}
