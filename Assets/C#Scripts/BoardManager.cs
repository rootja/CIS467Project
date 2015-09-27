using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public GameObject floorTile;
	public GameObject wallTile;

	public int rows;
	public int columns;

	private Transform boardTiles;
	
	public void SetupBoard(int rows = 1, int columns = 1){

		// Makes sure the rows value is greater than 0.
		if(rows > 0)
			this.rows = rows;
		else
			this.rows = 1;
		// Makes sure the columns value is greater than 0.
		if (columns > 0)
			this.columns = columns;
		else
			this.columns = 1;
	}
	
	// Use this for initialization
	void Start () {

		boardTiles = new GameObject ("BoardTiles").transform;

		// Assigns values to the column and row variables.
		SetupBoard (9, 9);
		
		// Adds the floor tiles to the game board.
		for (int i = 0; i < rows; i++) {
			for(int j = 0; j < columns; j++){
				// Creates a new tile game object at position (i,j).
				GameObject newTile = Instantiate(floorTile, new Vector2(i, j), Quaternion.identity) as GameObject;

				// Adds the new tile to GameObject called 'BoardTiles' to help reduce clutter in the
				// heirarchy.
				newTile.transform.SetParent(boardTiles);
			}
		}

		// Adds the wall tiles to the game board.
		for (int i = -1; i <= rows; i++) {
			for (int j = -1; j <= columns; j++){
				if(i == -1 || i == columns || j == -1 || j == columns){
					GameObject newTile = Instantiate(wallTile, new Vector2(i,j), Quaternion.identity) as GameObject;
					newTile.transform.SetParent(boardTiles);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
