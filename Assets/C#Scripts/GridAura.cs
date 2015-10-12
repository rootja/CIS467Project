using UnityEngine;
using System.Collections;

public class GridAura : MonoBehaviour {

	Animator animator;

	string spritename;

	int clr;

	int timer;

	float len;

	Vector2 temp;
	
	public Vector2 creator;

	// Use this for initialization
	void Start () {
	
		// Color to display of Aura Sprite Strip
		// "SquareAuraStrip_strip4_x" where x is one of the following ints
		// 0 = Red, 1 = Blue, 2 = Yellow, 3 = Green
		int clr = 2;
		//int dist = 1;
		spritename = "SquareAuraStrip_strip4_2";

		int timer = 5;

		Vector2 temp = this.transform.position;

		len = Vector2.Distance(temp,creator);

		animator = GetComponent<Animator>();
	}

	void OnTriggerStay(Collider2D other){

		if (other.tag == "Player") {
			clr = 3;
		}

		if (other.tag == "Wall") {
			clr = 0;
			if(len > 1){
//				Player.stopJump();
			}
			else{
//				Player.stopWalk();
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		//if(Collision2D.Equals(Player)){
		//	clr = 3;
		//}

		//really sloppy here, don't yell at me yet

		// Change sprite to the appropriate color
		spritename = "SquareAuraStrip_strip4_" + clr;
//		animator.Play (spritename);

		// This is kind of an experiment, probably not final
     	timer--;
		if (timer < 0) {
			timeup();
		}
	}

	void timeup () {

		Destroy(this.gameObject, 0.001F);

	}
}
