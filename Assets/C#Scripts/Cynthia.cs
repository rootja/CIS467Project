using UnityEngine;
using System.Collections;

public class Cynthia : Unit {

// The amount of health the player has.
	int health;
	// The player's current level.
	int level;
	// The amount of rupees that the player currently has.
	int currency;
	// The amount of experience the player has earned.
	int experience;

	string currentDirection = "south";

	Animator animator;

	BoardManager bm;

	public int rows;
	public int columns;

	// A string variable that we can change while playing the game or outside Play mode.
	public string myName;

	public void InitEnemy(string playerName = "Cynthia"){
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
		InitEnemy();
		this.transform.position = new Vector3(2,3,0);
		SetMoveLimits (9,9);
	}

	public override void Move(){
		Vector3 currentPosition = this.transform.position;
		// Updates the object's position to the new position.
		switch(currentDirection) {
			case "south":
				currentPosition = goSouth(currentPosition);
				break;
			case "north":
				currentPosition = goNorth(currentPosition);
				break;
			case "west":
				currentPosition = goWest(currentPosition);
				break;
			default:
				currentPosition = goEast(currentPosition);
				break;
		}
		this.transform.position = currentPosition;
	}

	public override GameObject[] Inventory(){
		return null;
	}

	public override void Attack(int x, int y){
		//Facing north
		if(x < 0 && y < 0)
			animator.Play ("garchomp_");
		//Facing West
		else if(x > 0 && y < 0)
			animator.Play ("garchomp_ 2");
		//Facing East
		else if(x > 0 && y > 0)
			animator.Play ("garchomp_1");
		//Facing south
		else if(x < 0 && y > 0)
		animator.Play ("garchomp_ 1");
	}

	// Update is called once per frame
	void Update () {
		int moveOrAttack = Random.Range(0,2);
		if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)){
			if(moveOrAttack == 1){
				Move();
			}
			else {
				switch(currentDirection) {
					case "south":
						Attack(-1,1);
						break;
					case "north":
						Attack(-1,-1);
						break;
					case "west":
						Attack(1,-1);
						break;
					default:
						Attack(1,1);
						break;
				}
			}
		}
	}
}
