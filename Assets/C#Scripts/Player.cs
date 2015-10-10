using UnityEngine;
using System.Collections;

public class Player : Unit {

	/*
	 * Static Input Keys
	 * 4 Directional Keys (keyUP, keyDOWN, keyLEFT, keyRIGHT)
	 * 4 Command Keys (keyMOVE, keyATTACK, keyITEM, keyCANCEL)
	 * 2 System Keys (keyPAUSE, keyEXIT)
	 */

	// Up
    public	static string keyUP = "up";
	// Down
	public	static string keyDOWN = "down";
	// Left
	public static string keyLEFT = "left";
	// Right
	public static string keyRIGHT = "right";

	// Enter walking mode and walk
	public static string keyMOVE = "a";
	// Enter targeting mode and attack
	public static string keyATTACK = "s";
	// Open Inventory to use items?
	public static string keyITEM = "d";
	// Exit other modes, including inventory
	public static string keyCANCEL = "space";

	//The following two keys may belong somewhere else, I just wanted to set a framework
	// Bring up Pause menu
	public static string keyPAUSE = "return";
	// Closes the program immediately, saving any states if neccesary
	public static string keyEXIT = "escape";

	Animator animator;

	BoardManager bm;

//	public int rows;
//	public int columns;

	public GridAura gridSpot;

	GridAura gridInstance;

	// A string variable that we can change while playing the game or outside Play mode.
	public string myName;

	public void InitPlayer(string playerName = "Link"){
		health = 3;
		level = 1;
		currency = 0;
		experience = 0;
		state = 0;
		maxmoves = 1.0;
		moves = maxmoves;
		myName = playerName;
		canWalk = true;
		canJump = true;
	}

	// Sets the borders for the player movement.
//	public void SetMoveLimits(int rows = 0, int columns = 0){
//		this.rows = rows;
//		this.columns = columns;
//	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

		// Ititializes the player stats.
		InitPlayer ();
//		SetMoveLimits (9,9);
	}

	public override GameObject[] Inventory(){
		// Will be used to store user items.
		return null;
	}

	public override void Move(){
		// Store position to prevent crazy additive movement
		this.transform.position = this.transform.position;
		
		// Checks for directional presses once, and converts them to ints
		// (for future method usage such as movement)
		
		// Store the directional presses of the player
		int x = 0;
		int y = 0;
		
		// Exclusive up
		if (PauseScript.isKeysEnabled && Input.GetKey (keyUP) & ! Input.GetKey (keyDOWN)) {
			y = 1;
		}
		// Exclusive down
		if (PauseScript.isKeysEnabled && Input.GetKey (keyDOWN) & ! Input.GetKey (keyUP)) {
			y = -1;
		}
		// Exclusive right
		if (PauseScript.isKeysEnabled && Input.GetKey (keyRIGHT) & ! Input.GetKey (keyLEFT)) {
			x = 1;
		}
		// Exclusive left
		if (PauseScript.isKeysEnabled && Input.GetKey (keyLEFT) & ! Input.GetKey (keyRIGHT)) {
			x = -1;
		}
		
		// ACTION STATES
		
		// Movement Decision State
		if (state == 1) {
			
			// Creates Jump-Range Grids
			gridInstance = Instantiate(gridSpot, new Vector3((this.transform.position.x + 2*x), (this.transform.position.y + 2*y), 0F), Quaternion.identity) as GridAura;
			
			gridInstance.creator = this.transform.position;
			
			// Moves the player to the appropriate grid.
			if (PauseScript.isKeysEnabled && Input.GetKeyDown (keyMOVE)) {
				walk (x,y,false);
			}
			// Jumps the player to the appropriate grid.
			if (PauseScript.isKeysEnabled && Input.GetKeyDown (keyATTACK)) {
				jump (x,y);
			}
			// Skips the turn.
			if (PauseScript.isKeysEnabled && Input.GetKeyDown (keyCANCEL)) {
				moves = 0;
			}
			
		}

		// Attack Decision State
		if (state == 2) {
			
			// Activates item in slot 1
			if (Input.GetKeyDown (keyMOVE)) {
				// item use code
			}
			// Attacks the target grid with the main weapon (sword?)
			if (Input.GetKeyDown (keyATTACK)) {
				attack (x,y);
			}
			// Activates item in slot 2
			if (Input.GetKeyDown (keyITEM)) {
				// item use code
			}
			
		}
		
		// All Active States
		if (state < 3) {
			
			// if it is your turn, and not in neutral state, show reticule
			// Places the targetting icon
			if (state > 0) {
				
				gridInstance = Instantiate(gridSpot, new Vector3((this.transform.position.x + x), (this.transform.position.y + y), 0F), Quaternion.identity) as GridAura;
				
				gridInstance.creator = this.transform.position;
				
			}
			
			// Returns the player to the neutral state.
			if (Input.GetKeyDown (keyCANCEL)) {
				state = 0;
			}
			
			// Checks if facing purely left.
			if ( (x == -1) & (y == 0) ) {
				animator.Play ("PlayerLeftIdle");
			} 
			// Checks if facing purely right.
			if ( (x == 1) & (y == 0) ) {
				animator.Play ("PlayerRightIdle");
			}
			// Checks if facing purely down.
			if ( (x == 0) & (y == -1) ) {
				animator.Play ("PlayerForwardIdle");
			} 
			// Checks if facing purely up.
			if ( (x == 0) & (y == 1) ) {
				animator.Play ("PlayerBackwardIdle");
			}
			
			// Checks if facing up-left.
			if ( (x == -1) & (y == 1) ) {
				//animator.Play ("PlayerUpLeftIdle");
			} 
			// Checks if facing up-right.
			if ( (x == 1) & (y == 1) ) {
				//animator.Play ("PlayerUpRightIdle");
			} 
			// Checks if facing down-left.
			if ( (x == -1) & (y == -1) ) {
				//animator.Play ("PlayerDownLeftIdle");
			} 
			// Checks if facing down-right.
			if ( (x == -1) & (y == 1) ) {
				//animator.Play ("PlayerDownRightIdle");
			} 
		}
		
		// Not My Turn State
		
		if (state == 4) {
			
			//not your turn cleanup
			
		}
		
		// State Checks
		
		if (state == 0) {
			
			// Check for move state
			if ((PauseScript.isKeysEnabled && Input.GetKeyDown (keyMOVE))) {
				state = 1;
			}
			
			// Check for attack state NOT READY
			//		if (Input.GetKeyDown (keyATTACK)) {
			//			state = 2;
			//		}
			
			//		// Check for item state NOT READY
			//		if (Input.GetKeyDown (keyITEM)) {
			//			state = 3;
			//		}
		}
		
		canWalk = true;
		canJump = true;

	}

	// Update is called once per frame
	void Update () {
		base.Update ();
		Move ();
	}

	//moves the character occording to the inputs
	void walk(int x, int y,bool jump){

		state = 3;

		//place to go
		Vector3 destination = new Vector3((this.transform.position.x + x),(this.transform.position.y + y), 0);

		//check if goal is a valid location
		if (jump & ! canJump) {
			//collision, do nothing
			//play bump noise
		}
		if (! jump & ! canWalk) {
			//collision, do nothing
			//play bump noise
		}
		//valid location, move to goal
		else {
			this.transform.position = destination;
			moves--;
		}

		state = 1;
		return;

	}

	//temporary jump fix, more interesting behavior to come
	void jump(int x, int y){

		Vector3 prepos = this.transform.position;

		x *= 2;
		y *= 2;

		walk (x, y, true);

		if (this.transform.position != prepos) {

			moves--;

		}
		
	}

	// attacks the target area with the basic attack
	void attack (int x, int y) {
		
		state = 3;
		
		// attack target location
		Vector3 goal = new Vector3((this.transform.position.x + x),(this.transform.position.y + y), 0);


		
		state = 1;
		return;
		
	}

	// Methods for GridAura to disable movement
//	public void stopWalk(){

//		canWalk = false;

//	}

//	public void stopJump(){
		
//		canJump = false;
		
//	}

}
