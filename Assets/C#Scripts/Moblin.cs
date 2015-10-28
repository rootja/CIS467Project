using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Moblin : Unit {

	Animator moblinAnimator;

	// The amount of space on the board to move each frame if a movement key is pressed down.
	const float MOVE_PER_FRAME = 0.02F;

	// The direction states for when the enemy is not moving.
	const string FORWARD_STATE = "MoblinForward";
	const string BACKWARD_STATE = "MoblinBackward";
	const string LEFT_STATE = "MoblinLeft";
	const string RIGHT_STATE = "MoblinRight";

	// The direction state the enemy is facing.
	static string state;

	public void InitMoblin(int level) {
		CalculateStats (level);
	}

	// Initializes key variables for the Moblin enemy.
	void Start () {
		InitMoblin (1);
		moblinAnimator = this.GetComponent<Animator> ();
		state = "MoblinForward";
	}

	public void CalculateStats(int level){
		this.Level = level;
		this.Health = 3;
		this.Attack = 1;
		this.Defence = 1;
		this.Speed = 1;
		this.Experience = 10 * level;

		for(int i = 1; i < level; i++){
			if(i % 2 == 0){
				this.Health++;
				this.Attack++;
				this.Defence++;
			}
			else {
				this.Attack++;
				this.Speed++;
			}
		}
	}

	public override void Move(){
		// Stores the Moblin's current position.
		Vector3 currentPostion = this.transform.position;

		// Normal 4-way Move Conditions.
		if (Input.GetKey(KeyCode.DownArrow) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))) {
			this.transform.position = new Vector3 (currentPostion.x, currentPostion.y + (MOVE_PER_FRAME*-1), 0F);
			moblinAnimator.Play("MoblinMovingForward");
			state = FORWARD_STATE;
		}
		if (Input.GetKey(KeyCode.UpArrow) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))) {
			this.transform.position = new Vector3 (currentPostion.x, currentPostion.y + MOVE_PER_FRAME, 0F);
			moblinAnimator.Play("MoblinMovingBackward");
			state = BACKWARD_STATE;
		}
		if (Input.GetKey(KeyCode.LeftArrow) && !(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))) {
			this.transform.position = new Vector3 (currentPostion.x + (MOVE_PER_FRAME*-1), currentPostion.y, 0F);
			moblinAnimator.Play ("MoblinMovingLeft");
			state = LEFT_STATE;
		}
		if (Input.GetKey(KeyCode.RightArrow) && !(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))) {
			this.transform.position = new Vector3 (currentPostion.x + MOVE_PER_FRAME, currentPostion.y, 0F);
			moblinAnimator.Play ("MoblinMovingRight");
			state = RIGHT_STATE;
		}

		// Diagonal Move Conditions.
		if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)) {
			this.transform.position = new Vector3 (currentPostion.x + (MOVE_PER_FRAME*-1), currentPostion.y + (MOVE_PER_FRAME*-1), 0F);
			moblinAnimator.Play("MoblinMovingForward");
			state = FORWARD_STATE;
		}
		if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow)) {
			this.transform.position = new Vector3 (currentPostion.x + (MOVE_PER_FRAME*-1), currentPostion.y + MOVE_PER_FRAME, 0F);
			moblinAnimator.Play("MoblinMovingBackward");
			state = BACKWARD_STATE;
		}
		if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow)) {
			this.transform.position = new Vector3 (currentPostion.x + MOVE_PER_FRAME, currentPostion.y + (MOVE_PER_FRAME*-1), 0F);
			moblinAnimator.Play("MoblinMovingForward");
			state = FORWARD_STATE;
		}
		if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow)) {
			this.transform.position = new Vector3 (currentPostion.x + MOVE_PER_FRAME, currentPostion.y + MOVE_PER_FRAME, 0F);
			moblinAnimator.Play("MoblinMovingBackward");
			state = BACKWARD_STATE;
		}

		// The direction state that the enemy is facing.
		if (!(Input.anyKey)) {
			switch(state){
			case "MoblinForward":
				moblinAnimator.Play("MoblinForwardIdle");
				break;
			case "MoblinBackward":
				moblinAnimator.Play("MoblinBackwardIdle");
				break;
			case "MoblinLeft":
				moblinAnimator.Play("MoblinLeftIdle");
				break;
			case "MoblinRight":
				moblinAnimator.Play("MoblinRightIdle");
				break;
			default:
				moblinAnimator.Play("MoblinForwardIdle");
				break;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		Move ();
	}
}
