using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public GameObject tile;

	public int rows;
	public int columns;
	
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
	void Awake () {

		// Assigns values to the column and row variables.
		SetupBoard (2, 2);
		
		// Creates a series of tiles based on the column and row input values.
		// Added from the origin(0,0).
		// In a case where rows = 2 and columns = 2, then the board will have a tile at
		// the origin (0,0) as well as every other location around it within 2 blocks of
		// the origin point.
		for (int i = rows*-1; i <= rows; i++) {
			for(int j = columns*-1; j <= columns; j++){
				// Adds a tile to the scene.
				Instantiate(tile, new Vector2(i, j), Quaternion.identity);
			}
		}

		Debug.Log ("Columns: " + columns + " Rows: " + rows);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
