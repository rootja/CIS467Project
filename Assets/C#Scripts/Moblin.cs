using UnityEngine;
using System.Collections;

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

	// Initializes key variables for the Moblin enemy.
	void Start () {
		moblinAnimator = this.GetComponent<Animator> ();
		state = "MoblinForward";
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

	public override GameObject[] Inventory(){
		return null;
	}

	// Update is called once per frame
	void Update () {
		Move ();
	}
}
