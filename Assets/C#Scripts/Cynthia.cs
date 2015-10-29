using UnityEngine;
using System.Collections;

public class Cynthia : Unit {

// The amount of health the player has.

	string currentDirection = "south";

	Animator animator;

	BoardManager bm;

	public int rows;
	public int columns;

	// A string variable that we can change while playing the game or outside Play mode.
	public string myName;

	public void InitPlayer(string unitName = "Cynthia"){
		this.Level = 3;
		this.Health = 5;
		this.Attack = 1;
		this.Defense = 1;
		this.Speed = 1;

		this.Currency = 10;
		this.Experience = 50;
		myName = unitName;
		state = 0;
		maxmoves = 1.0;
		moves = maxmoves;

		canWalk = true;
		canJump = true;
	}

	// Sets the borders for the player movement.
	public void SetMoveLimits(int rows = 0, int columns = 0){
		this.rows = rows;
		this.columns = columns;
	}

	private Vector3 goNorth(Vector3 currentPosition) {
		currentPosition.y++;		
		animator.Play ("cynthia_");
		if(currentPosition.y == columns - 1){
			//If you can't go north, choose a random direction and check if you can go that way
			switch (Random.Range(0,2)){
				case 0: 
					currentDirection = "south";
					break;
				case 1: 
					if(currentPosition.x != 0){
						currentDirection = "west";
					}else {
						currentDirection = "east";
					}
					break;
				case 2:
					if(currentPosition.x < rows - 1){
						currentDirection = "east";
					}else {
						currentDirection = "west";
					}
					break;
				default:
					currentDirection = "south";
					break;
			}
		}
		return currentPosition;
	}
	private Vector3 goSouth(Vector3 currentPosition) {
		currentPosition.y--;		
		animator.Play ("cynthia_ 1");
		if(currentPosition.y == 0){
			//If you can't go south, choose a random direction and check if you can go that way
			switch (Random.Range(0,2)){
				case 0: 
					currentDirection = "north";
					break;
				case 1: 
					if(currentPosition.x != 0){
						currentDirection = "west";
					}else {
						currentDirection = "east";
					}
					break;
				case 2:
					if(currentPosition.x < rows - 1){
						currentDirection = "east";
					}else {
						currentDirection = "west";
					}
					break;
				default:
					currentDirection = "north";
					break;
			}
		}
		return currentPosition;
	}
	private Vector3 goWest(Vector3 currentPosition) {
		currentPosition.x--;		
		animator.Play ("cynthia_ 2");
		if(currentPosition.x == 0){
			//If you can't go west, choose a random direction and check if you can go that way
			switch (Random.Range(0,2)){
				case 0: 
					currentDirection = "east";
					break;
				case 1: 
					if(currentPosition.y != 0){
						currentDirection = "south";
					}else {
						currentDirection = "north";
					}
					break;
				case 2:
					if(currentPosition.y < rows - 1){
						currentDirection = "north";
					}else {
						currentDirection = "south";
					}
					break;
				default:
					currentDirection = "east";
					break;
			}
		}		
		return currentPosition;
	}
	private Vector3 goEast(Vector3 currentPosition) {
		currentPosition.x++;		
		animator.Play ("cynthia_ 3");
		if(currentPosition.x == columns - 1){
			//If you can't go north, choose a random direction and check if you can go that way
			switch (Random.Range(0,2)){
				case 0: 
					currentDirection = "west";
					break;
				case 1: 
					if(currentPosition.y != 0){
						currentDirection = "south";
					}else {
						currentDirection = "north";
					}
					break;
				case 2:
					if(currentPosition.y < rows - 1){
						currentDirection = "north";
					}else {
						currentDirection = "south";
					}
					break;
				default:
					currentDirection = "west";
					break;
			}
		}
		return currentPosition;
	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

		// Ititializes the player stats.
		InitPlayer ();
		//this.transform.position = new Vector3(2,3,0);
		SetMoveLimits (9,9);
	}

	// Update is called once per frame
	void Update () {
		base.Update ();
		Move ();
	}

	//sub function'd for inheritence compatibility
	public override void Move () {
		Vector3 currentPosition = this.transform.position;

		// Checks if the player presses down the left arrow key and that they haven't reached the left border.
		/*if (Input.GetKeyDown (KeyCode.LeftArrow) && currentPosition.x != 0) {
			currentPosition.x--;
			animator.Play("cynthia_west");
		} 
		// Checks if the player presses down the right arrow key and that they haven't reached the right border.
		if (Input.GetKeyDown (KeyCode.RightArrow) && currentPosition.x < rows - 1) {
			currentPosition.x++;
			animator.Play("cynthia_east");
		}
		// Checks if the player presses down the down arrow key and that they haven't reached the bottom.
		if (Input.GetKeyDown (KeyCode.DownArrow) && currentPosition.y != 0) {
			currentPosition.y--;
			animator.Play("cynthia_south");
		} 
		// Checks if the player presses down the up arrow key and that they haven't reached the top.
		if (Input.GetKeyDown (KeyCode.UpArrow) && currentPosition.y < columns - 1) {
			currentPosition.y++;
			animator.Play ("cynthia_north");
		}
		*/
		// Updates the object's position to the new position.

//		if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)){
//			switch(currentDirection) {
//				case "south":
//					currentPosition = goSouth(currentPosition);
//					break;
//				case "north":
//					currentPosition = goNorth(currentPosition);
//					break;
//				case "west":
//					currentPosition = goWest(currentPosition);
//					break;
//				default:
//					currentPosition = goEast(currentPosition);
//					break;
//			}
//		}

		if(state < 4){
			switch(currentDirection) {
			case "south":
				currentPosition = goSouth(currentPosition);
				moves--;
				break;
			case "north":
				currentPosition = goNorth(currentPosition);
				moves--;
				break;
			case "west":
				currentPosition = goWest(currentPosition);
				moves--;
				break;
			default:
				currentPosition = goEast(currentPosition);
				moves--;
				break;
			}
		}

		this.transform.position = currentPosition;
	}
}
