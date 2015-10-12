using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour {

	// The amount of health the unit has.
	int hp;
	// The unit's current level.
	int lvl;
	// The amount of rupees that the unit currently has.
	int money;
	// The amount of experience the unit has(/will give?).
	int exp;
	// Action mode of the unit [0 = idle, 1 = movement, 2 = attacking, 3 = midmanuever, 4 = turnless]
	int stat;
	// Maximum amount of moves that an entity can make in one turn
	double maxmvs;
	// Remaining turns. (Some actions take partial movess, negative moves results in skipped turns
	double mvs;

	// variables to be adjusted by collision check
	bool walk;
	bool jump;

	// Health Property
	public int health
	{
		get { return hp; }
		set { hp = value; }
	}

	// Currency Property
	public int currency
	{
		get { return money; }
		set { money = value; }
	}

	// Experience Property
	public int experience
	{
		get { return exp; }
		set { exp = value; }
	}

	// Experience Property
	public int level
	{
		get { return lvl; }
		set { lvl = value; }
	}

	// State Property
	public int state
	{
		get { return stat; }
		set { stat = value; }
	}

	// Maxmoves Property
	public double maxmoves
	{
		get { return maxmvs; }
		set { maxmvs = value; }
	}

	// xmoves Property
	public double moves
	{
		get { return mvs; }
		set { mvs = value; }
	}

	// canWalk Property
	public bool canWalk
	{
		get { return walk; }
		set { walk = value; }
	}

	// canJump Property
	public bool canJump
	{
		get { return jump; }
		set { jump = value; }
	}

	// Every unit must have an algorithm or method of moving on the board.
	public abstract void Move();

	// Every unit must have an inventory.
	public abstract GameObject[] Inventory ();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {

		// If all actions have been taken this turn, end the turn
		if (moves <= 0){
			state = 4;
		}
		
		// returns to active state if it is your turn
		if (state == 4 & moves > 0) {
			state = 0;
		}
		
		// debug turn incrementor, will be incremented by 1 everytime it is my turn again in final product
		moves += 0.01;
		
		// Make sure moves are limited by maxmoves
		if (moves > maxmoves) {
			
			moves = maxmoves;
			
		}
	
	}
}
