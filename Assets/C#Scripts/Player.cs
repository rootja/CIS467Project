using UnityEngine;
using System.Collections;

public class Player : UnitMovement {

	// The amount of health the player has.
	int health;
	// The player's current level.
	int level;
	// The amount of rupees that the player currently has.
	int currency;
	// The amount of experience the player has earned.
	int experience;

	Animator animator;

	BoardManager bm;

	public int rows;
	public int columns;

	// A string variable that we can change while playing the game or outside Play mode.
	public string myName;

	public void InitPlayer(string playerName = "Link"){
		health = 3;
		level = 1;
		currency = 0;
		experience = 0;
		myName = playerName;
	}

	// Sets the borders for the player movement.
	public void SetMoveLimits(int rows = 0, int columns = 0){
		this.rows = rows;
		this.columns = columns;
	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

		// Ititializes the player stats.
		InitPlayer ();
		SetMoveLimits (9,9);
	}

	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = this.transform.position;

		// Checks if the player presses down the left arrow key and that they haven't reached the left border.
		if (Input.GetKeyDown (KeyCode.LeftArrow) && currentPosition.x != 0) {
			currentPosition.x--;
			animator.Play("PlayerLeftIdle");
		} 
		// Checks if the player presses down the right arrow key and that they haven't reached the right border.
		if (Input.GetKeyDown (KeyCode.RightArrow) && currentPosition.x < rows - 1) {
			currentPosition.x++;
			animator.Play("PlayerRightIdle");
		}
		// Checks if the player presses down the down arrow key and that they haven't reached the bottom.
		if (Input.GetKeyDown (KeyCode.DownArrow) && currentPosition.y != 0) {
			currentPosition.y--;
			animator.Play("PlayerForwardIdle");
		} 
		// Checks if the player presses down the up arrow key and that they haven't reached the top.
		if (Input.GetKeyDown (KeyCode.UpArrow) && currentPosition.y < columns - 1) {
			currentPosition.y++;
			animator.Play ("PlayerBackwardIdle");
		}

		// Updates the object's position to the new position.
		this.transform.position = currentPosition;
	}
}
