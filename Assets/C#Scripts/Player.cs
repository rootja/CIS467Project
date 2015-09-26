using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// A string variable that we can change while playing the game or outside Play mode.
	public string myName;

	int rows;
	int columns;

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

		// Assigns values to the column and row variables.
		SetupBoard (4, 4);

		// Creates a series of black squares based on the column and row input values.
		// Added from the origin(0,0).
		// In a case where rows = 2 and columns = 2, then the board will have a tile at
		// the origin (0,0) as well as every other location around it within 2 blocks of
		// the origin point.
		for (int i = rows*-1; i <= rows; i++) {
			for(int j = columns*-1; j <= columns; j++){
				// A black tile object.
				GameObject block = GameObject.CreatePrimitive(PrimitiveType.Quad);
				// Adds the block to the scene.
				Instantiate(block, new Vector2(i, j), Quaternion.identity);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = this.transform.position;
		// Checks if the player presses down the left arrow key and that they haven't reached the left border.
		if (Input.GetKeyDown (KeyCode.LeftArrow) && currentPosition.x != (rows*-1)) {
			currentPosition.x--;
		} 
		// Checks if the player presses down the right arrow key and that they haven't reached the right border.
		if (Input.GetKeyDown (KeyCode.RightArrow) && currentPosition.x != rows) {
			currentPosition.x++;
		}
		// Checks if the player presses down the down arrow key and that they haven't reached the bottom.
		if (Input.GetKeyDown (KeyCode.DownArrow) && currentPosition.y != (columns*-1)) {
			currentPosition.y--;
		} 
		// Checks if the player presses down the up arrow key and that they haven't reached the top.
		if (Input.GetKeyDown (KeyCode.UpArrow) && currentPosition.y != columns) {
			currentPosition.y++;
		}
		// Updates the object's position to the new position.
		this.transform.position = currentPosition;
	}
}
