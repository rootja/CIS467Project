using UnityEngine;
using System;
using System.Collections;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public GameObject floorTile;
	public GameObject wallTile;

	public GameObject[] items;

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

		// May generate up to 5 items on the board.
		GenerateItems (5);
	}

	// Generates an item and places it at some random position on the board. Note: The floor lining the wall
	// will not have items in it. This is so that the player doesn't get blocked when we add obstacles.
	public void GenerateItems(int numberOfItems){
		// Holds the positions of each item added to the game board.
		List<Vector3> positions = new List<Vector3> ();

		// Adds items at random positions on the board.
		for (int i = 0; i < numberOfItems; i++) {
			// Values between 1 and 8.
			float x = (int)(Random.value * (columns-2)+1);
			// Values between 1 and 8.
			float y = (int)(Random.value * (rows-2)+1);

			// -1 for the z-axis allows the sprite to be displayed in front of the tile.
			Vector3 location = new Vector3(x,y,-1);

			if(positions.Contains(location) == false){
				positions.Add(location);
				Instantiate (RandomItem(), location, Quaternion.identity);
			}
		}
	}

	GameObject RandomItem(){
		// Generates a random number between 0 and the size of the list of items.
		int randomNum = (int) (Random.value * items.Length);

		GameObject obj = items[randomNum];

		return obj;

	}
	
	// Update is called once per frame
	void Update () {

	}
}
